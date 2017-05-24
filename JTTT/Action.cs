using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    /*Base class for other actions*/
    public class Action
    {
        //info about GUI components for specific action
        public string Label1Text, Label2Text, Label3Text;
        public bool isTextBox1Visible, isTextBox2Visible;

        public virtual EmailModel prepareEmail(string arg1, string arg2) { return new EmailModel(); }
    }
}
