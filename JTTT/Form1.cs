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
using HtmlAgilityPack; //parse html

namespace JTTT
{
    public partial class Form1 : Form
    {
        private WebClient client;
        string ImgURL, Description;

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
            try
            {
                Stream data = client.OpenRead(textBox1.Text);
                StreamReader reader = new StreamReader(data);
                string site = reader.ReadToEnd();

                //search for images in html
                var doc = new HtmlAgilityPack.HtmlDocument();
                var pageHtml = site;
                doc.LoadHtml(pageHtml);
                var nodes = doc.DocumentNode.Descendants("img");
                foreach (var node in nodes)
                {
                    if (node.GetAttributeValue("alt", "").Contains(textBox2.Text) && node.GetAttributeValue("src", "").Contains("http"))
                    {
                        
                        ImgURL = node.GetAttributeValue("src", "");
                        Description = node.GetAttributeValue("alt", "");
                        //debug
                        richTextBox1.Text = richTextBox1.Text + ImgURL + "\n";
                        richTextBox1.Text = richTextBox1.Text + Description + "\n";
                    }
                }
            }
            catch(System.ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Blad!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Szukaj po tagach":
                    label1.Text = "Podaj adres URL:";
                    label2.Text = "Podaj tag";
                    textBox1.Text = "http://demotywatory.pl/";
                    textBox2.Text = "Chin";
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
