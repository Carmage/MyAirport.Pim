using System;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewBagage_Click(object sender, EventArgs e)
        {
            // Reset all interface fields
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<MyAirport.Pim.Entities.BagageDefinition> bagageList = MyAirport.Pim.Models.Factory.Model.GetBagage(textBoxCodeIata.Text);

            if (bagageList.Count == 0) // Enter create mode
            {

            } else if (bagageList.Count == 1) // Fill in the textBoxes underneath the "Code IATA" label
            {
                MyAirport.Pim.Entities.BagageDefinition bagage = bagageList[0];
                textBoxIdBagage.Text = Convert.ToString(bagage.IdBagage);
                textBoxIdBagage.ReadOnly = true;
                textBoxCompagnie.Text = bagage.Compagnie;
                textBoxCompagnie.ReadOnly = true;
                textBoxLigne.Text = bagage.Ligne;
                textBoxLigne.ReadOnly = true;
                textBoxDateVol.Text = Convert.ToString(bagage.DateVol);
                textBoxDateVol.ReadOnly = true;
                textBoxItineraire.Text = bagage.Itineraire;
                textBoxItineraire.ReadOnly = true;
                textBoxPrioritaire.Text = bagage.Prioritaire ? "Yes" : "No";
                textBoxPrioritaire.ReadOnly = true;
                textBoxEnContinuation.Text = bagage.EnContinuation ? "Yes" : "No";
                textBoxEnContinuation.ReadOnly = true;
            } else // Display a popup with all the bagage found
            {

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void lblItineraire_Click(object sender, EventArgs e)
        {

        }

        private void lblPrioritaire_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPrioritaire_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxItineraire_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEnContinuation_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEnContinuation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}