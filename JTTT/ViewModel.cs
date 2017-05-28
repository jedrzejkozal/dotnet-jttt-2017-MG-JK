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
        private DataModel model;
        Action action; //strategy design pattern
        NotificationMethod notificiation;
        ViewLayout viewlayout;

        public ViewModel(View v)
        {
            view = v;
            model = new DataModel();
            action = new ActionNone();
            notificiation = new NotificationNone();
            viewlayout = new ViewLayout(" ", " ", " ", true, false);
            view.changeView(viewlayout);
        }

        //Action class is used to store information what should be done and in wich way
        //Also has some information about layout of View - some actions may take less TextBoxes then the others
        public void changeAction(string newAction)
        {
            switch (newAction) //parse string to action
            {
                case "Szukaj po tagach":
                    action = new SearchImageWebSite();
                    viewlayout = new ViewLayout("Podaj adres URL:", "Podaj szukany tag", "Podaj maila:", true, true);
                    break;
                case "Szukaj w .txt":
                    action = new SearchTxt();
                    break;
                case "Sprawdź pogodę we Wrocławiu":
                    action = new CheckWeather();
                    viewlayout = new ViewLayout("Podaj datę, w której chcesz sprawdzić pogodę w formacie RRRRMMDD"," ", "Podaj maila:", true, false);
                    break;
                default:
                    action = new ActionNone();
                    viewlayout = new ViewLayout(" ", " ", " ", true, false);
                    break;
            }
            view.changeView(viewlayout);
        }

        public void changeNotificationMethod(string newMethod)
        {
            view.ShowDebugMessage(newMethod);
            switch (newMethod)
            {
                case "Wyślij email":
                    notificiation = new NotificationEmail();
                    break;
                default:
                    notificiation = new NotificationNone();
                    break;
            }
        }

        //prepere data using avalible Models
        public void getData(string arg1, string arg2)
        {
            try
            {
                model = action.prepareEmail(arg1, arg2);
                //debug
                view.ShowDebugMessage(model.ImgURL);
                view.ShowDebugMessage(model.Description);
            }
            catch(System.ArgumentException exception)
            {
                view.ShowMessageBoxError(exception.Message, "Blad!");
            }
        }

        public string send(string adress)
        {
            try
            {
                //model = action.prepareEmail(arg1, arg2);
                //debug
                //view.ShowDebugMessage(model.ImgURL);
                //view.ShowDebugMessage(model.Description);
                model.adress = adress;
                return notificiation.notify(model);
            }
            catch (System.ArgumentException exception)
            {
                view.ShowMessageBoxError(exception.Message, "Blad!");
                return null;
            }

        }
    }
}
