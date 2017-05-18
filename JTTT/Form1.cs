using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text =  "No elo";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Szukaj po tagach":
                    label1.Text = "Podaj adres URL:";
                    break;
                case "Szukaj w .txt":

                    break;
                case "Sprawdź pogodę":

                    break;

                default:

                    break;
            }
        }
    }
}
