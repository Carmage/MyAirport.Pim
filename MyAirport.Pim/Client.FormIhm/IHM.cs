using System;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class IHM : Form
    {
        public IHM()
        {
            InitializeComponent();
            btnNewBagage_Click(this, null);
        }

        private void SetTextBox(System.Windows.Forms.TextBox t, String newText, bool visible, bool readOnly)
        {
            t.Text = newText;
            t.Visible = visible;
            t.ReadOnly = readOnly;
        }

        private void btnNewBagage_Click(object sender, EventArgs e)
        {
            // Reset all interface fields
            labelCodeIata.Visible = true;
            SetTextBox(textBoxPrestataire, "", true, false);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<MyAirport.Pim.Entities.BagageDefinition> bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(textBoxCodeIata.Text);

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
                SetTextBox(textBoxPrioritaire, GetStringPrioritaire(bagage.Prioritaire), true, true);
                labelEnContinuation.Visible = true;
                SetTextBox(textBoxEnContinuation, GetStringPrioritaire(bagage.EnContinuation), true, true);
            }
            else // Display a popup with all the bagage found
            {

            }
        }

        private string GetStringPrioritaire(bool prioritaire)
        {
            return prioritaire ? "Oui" : "Non";
        }

        private string GetFullCompanyName(String compagnie)
        {
            // TODO : aller rechercher le nom complet de la compagnie en fonction de son abréviation "compagnie"
            return compagnie;
        }
    }
}