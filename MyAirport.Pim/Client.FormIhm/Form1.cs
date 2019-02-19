using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAirport.Pim.Models;
using MyAirport.Pim.Entities;

namespace Client.FormIhm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reset all interface fields
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bagage = MyAirport.Pim.Models.Factory.Model.GetBagage(24388403);
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

        private void button3_Click(object sender, EventArgs e)
        {
            var bagage = MyAirport.Pim.Models.Factory.Model.GetBagage(tbCodeIata.Text);
        }
    }
}
