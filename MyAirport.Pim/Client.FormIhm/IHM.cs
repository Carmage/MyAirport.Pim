using System;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class IHM : Form
    {
        public IHM()
        {
            InitializeComponent();
            ResetInterface();
        }

        private void ResetInterface()
        {
            // Reset all interface fields
            labelResultatRecherche.Visible = false;
            labelResultatRecherche.Text = "";
            labelResultatRecherche.ForeColor = System.Drawing.Color.Black;
            labelCodeIata.Visible = true;
            SetTextBox(textBoxPrestataire, textBoxPrestataire.Text, true, false);
            SetTextBox(textBoxCodeIata, "", true, false);
            labelIdBagage.Visible = false;
            SetTextBox(textBoxIdBagage, "", false, true);
            labelCompagnie.Visible = false;
            SetTextBox(textBoxCompagnie, "", false, true);
            labelLigne.Visible = false;
            SetTextBox(textBoxLigne, "", false, true);
            labelDateVol.Visible = false;
            SetTextBox(textBoxDateVol, "", false, true);
            labelItineraire.Visible = false;
            SetTextBox(textBoxItineraire, "", false, true);
            labelPrioritaire.Visible = false;
            SetTextBox(textBoxPrioritaire, "", false, true);
            labelEnContinuation.Visible = false;
            SetTextBox(textBoxEnContinuation, "", false, true);
        }

        private void SetTextBox(System.Windows.Forms.TextBox t, String newText, bool visible, bool readOnly)
        {
            t.Text = newText;
            t.Visible = visible;
            t.ReadOnly = readOnly;
        }

        private string GetStringFromBool(bool b)
        {
            return b ? "Oui" : "Non";
        }

        private string GetFullCompanyName(String compagnie)
        {
            // TODO : aller rechercher le nom complet de la compagnie en fonction de son abréviation "compagnie"
            return compagnie;
        }

        private void btnNewBagage_Click(object sender, EventArgs e)
        {
            ResetInterface();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetTextBox(textBoxPrestataire, textBoxPrestataire.Text, true, true);
            SetTextBox(textBoxCodeIata, textBoxCodeIata.Text, true, true);
            labelResultatRecherche.Visible = false;
            string codeIataBagage = SanitizeCodeIata(textBoxPrestataire.Text, textBoxCodeIata.Text);

            if (codeIataBagage is null)
            {
                return;
            }

            System.Collections.Generic.List<MyAirport.Pim.Entities.BagageDefinition> bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIataBagage);

            if (bagageList.Count == 0) // Enter create mode
            {

            }
            else if (bagageList.Count == 1) // Fill in the textBoxes underneath the "Code IATA" label
            {
                MyAirport.Pim.Entities.BagageDefinition bagage = bagageList[0];
                labelIdBagage.Visible = true;
                SetTextBox(textBoxIdBagage, Convert.ToString(bagage.IdBagage), true, true);
                labelCompagnie.Visible = true;
                SetTextBox(textBoxCompagnie, GetFullCompanyName(bagage.Compagnie), true, true);
                labelLigne.Visible = true;
                SetTextBox(textBoxLigne, bagage.Ligne, true, true);
                labelDateVol.Visible = true;
                SetTextBox(textBoxDateVol, Convert.ToString(bagage.DateVol), true, true);
                labelItineraire.Visible = true;
                SetTextBox(textBoxItineraire, bagage.Itineraire, true, true);
                labelPrioritaire.Visible = true;
                SetTextBox(textBoxPrioritaire, GetStringFromBool(bagage.Prioritaire), true, true);
                labelEnContinuation.Visible = true;
                SetTextBox(textBoxEnContinuation, GetStringFromBool(bagage.EnContinuation), true, true);
            }
            else // Display a popup with all the bagage found
            {

            }
        }

        private string SanitizeCodeIata(string prestataire, string codeIata)
        {
            Console.WriteLine("SanitizeCodeIata");
            bool error = false;
            string message = "";

            if (prestataire.Length != 4)
            {
                error = true;
                message += "Le code prestataire doit comporter 4 chiffres.";
            }

            if (codeIata.Length < 6 || codeIata.Length > 8)
            {
                error = true;
                message = message.Equals("") ? message : message + " ";
                message += "Le code de droite doit comporter 6 à 8 chiffres.";
            }

            if (error)
            {
                Warn(message);
                return null;
            }

            while (codeIata.Length != 8)
            {
                codeIata += '0';
            }

            return prestataire + codeIata;
        }

        private void Warn(string message)
        {
            labelResultatRecherche.ForeColor = System.Drawing.Color.Red;
            labelResultatRecherche.Text = message;
            labelResultatRecherche.Visible = true;
        }
    }
}