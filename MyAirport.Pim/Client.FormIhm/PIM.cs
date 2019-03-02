using System;
using System.Windows.Forms;
using ClientPim;
using System.Collections.Generic;
using MyAirport.Pim.Entities;

namespace Client.FormIhm
{
    public partial class PIM : Form
    {
        private PimState state = PimState.AttenteBagage;
        private PimState State
        {
            get { return state; }
            set { OnPimStateChanged(value); }
        }

        public PIM()
        {
            InitializeComponent();
            PimStateChanged += PIM_PimStateChanged;
        }

        void PIM_PimStateChanged(object sender, PimState state)
        {
            toolStripStatusLabelEtat.Text = state.ToString();
        }

        public event PimStateEventHandler PimStateChanged;

        public delegate void PimStateEventHandler(object sender, PimState state);

        private void OnPimStateChanged(PimState newState)
        {
            if (newState != state)
            {
                state = newState;
                PimStateChanged?.Invoke(this, state);
            }
        }

        private void ResetInterface()
        {
            btnRechercher.Enabled = true;
            SetTextBox(textBoxCodeIata, "", false);
            SetTextBox(textBoxCompagnie, "", true);
            SetTextBox(textBoxAlpha, "", true);
            SetTextBox(textBoxLigne, "", true);
            SetTextBox(textBoxDateVol, "", true);
            SetTextBox(textBoxItineraire, "", true);
            SetTextBox(textBoxClasseBagage, "", true);
            btnCreer.Enabled = false;
            checkBoxContinuation.Enabled = false;
            checkBoxRush.Enabled = false;
            toolStripStatusLabelMessages.Text = "";
            btnCreer.Enabled = false;
            OnPimStateChanged(PimState.AttenteBagage);
        }

        private void SetTextBox(TextBox t, string newText, bool readOnly)
        {
            t.Text = newText;
            t.ReadOnly = readOnly;
        }
        
        private void btnNewBagage_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }
        
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(textBoxCodeIata.Text))
            {
                string codeIata = textBoxCodeIata.Text;
                ResetInterface();
                textBoxCodeIata.Text = codeIata;
                Message("Le code IATA ne doit être composé que de chiffres.");
                return;
            }

            if (textBoxCodeIata.Text.Length < 6 || textBoxCodeIata.Text.Length > 12)
            {
                string codeIata = textBoxCodeIata.Text;
                ResetInterface();
                textBoxCodeIata.Text = codeIata;
                Message("le code IATA comprend 6 à 12 chiffres.");
                return;
            }

            string codeIataBagage = textBoxCodeIata.Text;

            SetTextBox(textBoxCodeIata, codeIataBagage, true);
            List<BagageDefinition> bagageList;

            try
            {
                bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIataBagage);
               
                if (!(bagageList is null)) // If the bagageList is not null it means we have exactly one bagage
                {
                    toolStripStatusLabelMessages.Text = "";
                    OnPimStateChanged(PimState.AffichageBagage);
                    BagageDefinition bagage = bagageList[0];
                    btnRechercher.Enabled = false;
                    SetTextBox(textBoxCompagnie, bagage.NomCompagnie, true);
                    SetTextBox(textBoxAlpha, bagage.Compagnie, true);
                    SetTextBox(textBoxLigne, bagage.Ligne, true);
                    SetTextBox(textBoxDateVol, Convert.ToString(bagage.DateVol), true);
                    SetTextBox(textBoxItineraire, bagage.Itineraire, true);
                    SetTextBox(textBoxClasseBagage, bagage.ClasseBagage, true);
                    checkBoxRush.Enabled = false;
                    checkBoxRush.Checked = bagage.Rush;
                    checkBoxContinuation.Enabled = false;
                    checkBoxContinuation.Checked = bagage.EnContinuation;
                }
                else if (textBoxCodeIata.Text.Length == 12) // Create bagage mode
                {
                    toolStripStatusLabelMessages.Text = "";
                    OnPimStateChanged(PimState.CreationBagage);
                    btnRechercher.Enabled = false;
                    SetTextBox(textBoxCodeIata, textBoxCodeIata.Text, true);
                    SetTextBox(textBoxCompagnie, "", false);
                    SetTextBox(textBoxAlpha, "", false);
                    SetTextBox(textBoxLigne, "", false);
                    SetTextBox(textBoxDateVol, "", false);
                    SetTextBox(textBoxItineraire, "", false);
                    SetTextBox(textBoxClasseBagage, "", false);
                    btnCreer.Enabled = true;
                    checkBoxRush.Enabled = true;
                    checkBoxContinuation.Enabled = true;
                }
                else
                {
                    string codeIata = textBoxCodeIata.Text;
                    ResetInterface();
                    textBoxCodeIata.Text = codeIata;
                    Message("Le code IATA doit comporter 12 chiffres lors de la création");
                    MessageBox.Show("Le code IATA doit comporter 12 chiffres lors de la création", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (ApplicationException ae) // Several bagages were found
            {
                MessageBox.Show("Plusieurs bagages ont été trouvés", "Fonctionnalité indisponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCodeIata.Enabled = true;
            }
            catch // An other error occured
            {
                MessageBox.Show("Une erreur s’est produite dans le traitement de votre demande.\nMerci de bien vouloir re-tester ultérieurement ou de contacter votre administrateur.", "Erreur dans le traitement de votre demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Message(string message) => toolStripStatusLabelMessages.Text = message;

        private void toolStripMenuReinitialiser_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            string message;

            if (MyAirport.Pim.Models.Factory.Model.InsertBagage(
                    textBoxCodeIata.Text,
                    checkBoxContinuation.Checked,
                    textBoxLigne.Text,
                    textBoxCompagnie.Text,
                    textBoxAlpha.Text,
                    textBoxDateVol.Text,
                    textBoxClasseBagage.Text,
                    textBoxItineraire.Text,
                    checkBoxRush.Checked,
                    out message
                ))
            {
                MessageBox.Show(message, "Création de bagage réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInterface();
            }
            else
            {
                MessageBox.Show(message, "Echec de la création du bagage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}