using System;
using System.Windows.Forms;
using ClientPim;

namespace Client.FormIhm
{
    public partial class PIM : Form
    {
        private PimState state = PimState.Deconnecter;
        private PimState State
        {
            get { return state; }
            set { OnPimStateChanged(value); }
        }

        public PIM()
        {
            InitializeComponent();
            // ResetInterface();
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
            // ActiveControl = textBoxCodeIata;
            // Reset all interface fields
            SetTextBox(textBoxCodeIata, "", false);
            SetTextBox(textBoxCompagnie, "", true);
            SetTextBox(textBoxAlpha, "", true);
            SetTextBox(textBoxLigne, "", true);
            SetTextBox(textBoxDateVol, "", true);
            SetTextBox(textBoxItineraire, "", true);
            SetTextBox(textBoxClasseBagage, "", true);
            checkBoxContinuation.Enabled = false;
            checkBoxRush.Enabled = false;
            toolStripStatusLabelMessages.Text = "";
            OnPimStateChanged(PimState.Deconnecter);
        }

        private void SetTextBox(TextBox t, string newText, bool readOnly)
        {
            t.Text = newText;
            t.ReadOnly = readOnly;
        }

        private string GetFullCompanyName(string codeIataCompagnie)
        {
            return MyAirport.Pim.Models.Factory.Model.GetNomCompagnieFromIata(codeIataCompagnie);
        }

        private void btnNewBagage_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string codeIataBagage = SanitizeCodeIata(textBoxCodeIata.Text);

            SetTextBox(textBoxCodeIata, textBoxCodeIata.Text, true);
            System.Collections.Generic.List<MyAirport.Pim.Entities.BagageDefinition> bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIataBagage);

            // TODO Créer l'exception pour gérer le cas où on a 0 bagages retournés

            if (bagageList.Count == 0) // Enter create mode
            {
                toolStripStatusLabelMessages.Text = "";
                OnPimStateChanged(PimState.CreationBagage);
            }
            else if (bagageList.Count == 1)
            {
                toolStripStatusLabelMessages.Text = "";
                OnPimStateChanged(PimState.AffichageBagage);
                MyAirport.Pim.Entities.BagageDefinition bagage = bagageList[0];
                SetTextBox(textBoxCompagnie, GetFullCompanyName(bagage.Compagnie), true);
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
            else // Display a popup with all the bagage found
            {

            }
        }

        private string SanitizeCodeIata(string codeIata)
        {
            if (codeIata.Length < 10 || codeIata.Length > 12)
            {
                Message("Le code IATA doit comporter 10 à 12 chiffres.");
                return codeIata;
            }

            while (codeIata.Length != 12)
            {
                codeIata += '0';
            }

            return codeIata;
        }

        private void Message(string message)
        {
            toolStripStatusLabelMessages.Text = message;
        }

        private void toolStripMenuReinitialiser_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }
    }
}