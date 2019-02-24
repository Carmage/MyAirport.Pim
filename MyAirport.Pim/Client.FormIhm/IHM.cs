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
            // ActiveControl = textBoxCodeIata;
            // Reset all interface fields
            SetTextBox(textBoxCodeIata, "", true, false);
            SetTextBox(textBoxCompagnie, "", true, true);
            SetTextBox(textBoxLigne, "", true, true);
            SetTextBox(textBoxDateVol, "", true, true);
            SetTextBox(textBoxItineraire, "", true, true);
            SetTextBox(textBoxClasseBagage, "", true, true);
            checkBoxContinuation.Enabled = false;
            checkBoxRush.Enabled = false;
            toolStripStatusLabelMessages.Text = "";
            toolStripStatusLabelEtat.Text = "";
        }

        private void SetTextBox(System.Windows.Forms.TextBox t, String newText, bool visible, bool readOnly)
        {
            t.Text = newText;
            t.Visible = visible;
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

            if (codeIataBagage is null)
            {
                return;
            }

            SetTextBox(textBoxCodeIata, textBoxCodeIata.Text, true, true);
            System.Collections.Generic.List<MyAirport.Pim.Entities.BagageDefinition> bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIataBagage);

            if (bagageList.Count == 0) // Enter create mode
            {

            }
            else if (bagageList.Count == 1) // Fill in the textBoxes underneath the "Code IATA" label
            {
                MyAirport.Pim.Entities.BagageDefinition bagage = bagageList[0];
                SetTextBox(textBoxCompagnie, GetFullCompanyName(bagage.Compagnie), true, true);
                SetTextBox(textBoxLigne, bagage.Ligne, true, true);
                SetTextBox(textBoxDateVol, Convert.ToString(bagage.DateVol), true, true);
                SetTextBox(textBoxItineraire, bagage.Itineraire, true, true);
                SetTextBox(textBoxClasseBagage, bagage.ClasseBagage, true, true);
                checkBoxRush.Enabled = true;
                checkBoxRush.Checked = bagage.Rush;
                checkBoxContinuation.Enabled = true;
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
                return null;
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