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

        
        private void confirm_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VM.getData(jesliTextBox1.Text, jesliTextBox2.Text, toTextBox.Text);
            VM.addToList();
        }

        private void Perform_Click(object sender, EventArgs e)
        {
            //Debug.Text = "Adres został pobrany " + toTextBox.Text;
            Debug.Text += VM.send();
        }

        private void actionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            VM.changeAction(actionSelect.SelectedItem.ToString());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            VM.clear();
        }

        //layout and look of view is dependent from aplication logic
        //this method is a way to actualise a view whenever ViewModel needs it
        public void changeView(ViewLayout action)
        {
            label1.Text = action.Label1Text;
            label2.Text = action.Label2Text;
            label3.Text = action.Label3Text;
            jesliTextBox1.Visible = action.isTextBox1Visible;
            jesliTextBox2.Visible = action.isTextBox2Visible;
            button1.Visible = action.isButton1Visible;

            //for easier debug
            jesliTextBox1.Text = "http://demotywatory.pl/";
            jesliTextBox2.Text = "Chin";
        }

        //very convenient way to work with exceptions in ViewModel
        public void ShowMessageBoxError(string Message, string Title)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void addSourceToList(BindingList<Tuple<DataModel, Action, NotificationMethod>> arg)
        {
            listBox1.DataSource = arg;
        }

        public void ShowDebugMessage(string msg)
        {
            Debug.Text = Debug.Text + msg;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VM.changeNotificationMethod(comboBox1.SelectedItem.ToString());
        }

        private void Serialize_Click(object sender, EventArgs e)
        {
            Debug.Text = VM.serialize();
            VM.clear();
        }

        private void Desirialize_Click(object sender, EventArgs e)
        {
            Debug.Text = VM.deserialize();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
