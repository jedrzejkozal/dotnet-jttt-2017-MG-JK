using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net; //conection to web page
using System.IO;  //Stream and Stream reader

namespace JTTT
{
    public partial class Form1 : Form
    {
        private WebClient client;

        public Form1()
        {
            InitializeComponent();
            client = new WebClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text =  "No elo";
            try
            {
                //client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream data = client.OpenRead(textBox1.Text);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                richTextBox1.Text = s;
            }
            catch(System.ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Blad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.SelectedItem.ToString();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Szukaj po tagach":
                    label1.Text = "Podaj adres URL:";
                    label2.Text = "Podaj tag";
                    
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
