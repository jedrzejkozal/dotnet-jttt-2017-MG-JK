using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    /*ViewModel is bridge beetwen View and Model
    Uses Models to operate on data, and react to events from View
    ViewModel has whole logic of program*/
    class ViewModel
    {
        private View view;
        private EmailModel model;
        Action action; //strategy design pattern

        public ViewModel(View v)
        {
            view = v;
            model = new EmailModel();
            action = new ActionNone();
            view.changeView(action);
        }

        //Action class is used to store information what should be done and in wich way
        //Also has some information about layout of View - some actions may take less TextBoxes then the others
        public void changeAction(string newAction)
        {
            switch (newAction) //parse string to action
            {
                case "Szukaj po tagach":
                    action = new SearchImageWebSite();
                    break;
                case "Szukaj w .txt":
                    action = new SearchTxt();
                    break;
                case "Sprawdź pogodę":
                    action = new CheckWeather();
                    break;
                default:
                    action = new ActionNone();
                    break;
            }
            view.changeView(action);
        }

        //prepere data using avalible Models
        public void getData(string arg1, string arg2)
        {
            try
            {
                EmailModel email = action.prepareEmail(arg1, arg2);
                //debug
                view.ShowDebugMessage(email.ImgURL);
                view.ShowDebugMessage(email.Description);
            }
            catch(System.ArgumentException exception)
            {
                view.ShowMessageBoxError(exception.Message, "Blad!");
            }
        }

        public void sendEmail()
        {
            //to do
        }
    }
}
