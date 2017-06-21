using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class ViewLayout
    {
        public string Label1Text, Label2Text, Label3Text;
        public bool isTextBox1Visible, isTextBox2Visible, isButton1Visible, isWeatherBoxVisible, isWeatherPictureVisible;

        public ViewLayout()
        {
            Label1Text = Label2Text = Label3Text = " ";
            isTextBox1Visible = isTextBox2Visible = isButton1Visible = true;
        }

        public ViewLayout(string _label1Text, string _label2Text, string _label3Text, bool _is1Visible, bool _is2Visible, bool _isButtonVisible)
        {
            Label1Text = _label1Text;
            Label2Text = _label2Text;
            Label3Text = _label3Text;
            isTextBox1Visible = _is1Visible;
            isTextBox2Visible = _is2Visible;
            isButton1Visible = _isButtonVisible;
            isWeatherBoxVisible = _isButtonVisible;
            isWeatherPictureVisible = _isButtonVisible;
        }
    }
}
