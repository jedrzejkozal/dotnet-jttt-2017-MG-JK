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
    /*View in Model View ViewModel Pattern
    Represent GUI (ONLY) - all elements of UserInterface + handelers for this elements.
    Communicates with ViewModel*/
    public partial class View : Form
    {
        private ViewModel VM;

        public View()
        {
            InitializeComponent();
            //create ViewModel - this as argument in constructor gives ability to comunicate in both ways
            VM = new ViewModel(this);
        }

        private void Form1_Load(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e)
        {
            VM.getData(textBox1.Text, textBox2.Text);
            VM.sendEmail();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VM.changeAction(comboBox1.SelectedItem.ToString());
        }

        //layout and look of view is dependent from aplication logic
        //this method is a way to actualise a view whenever ViewModel needs it
        public void changeView(Action action)
        {
            label1.Text = action.Label1Text;
            label2.Text = action.Label2Text;
            textBox1.Visible = action.isTextBox1Visible;
            textBox2.Visible = action.isTextBox2Visible;

            //for easier debug
            textBox1.Text = "http://demotywatory.pl/";
            textBox2.Text = "Chin";
        }

        //very convenient way to work with exceptions in ViewModel
        public void ShowMessageBoxError(string Message, string Title)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowDebugMessage(string msg)
        {
            richTextBox1.Text = richTextBox1.Text + msg;
        }
    }
}
