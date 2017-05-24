using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

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

        public string sendEmail(string emailAddress)
        {

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("jttt.net@gmail.com");

            SmtpClient smtp = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jttt.net@gmail.com", "haslo1234"),
                Host = "smtp.gmail.com"
            };

            msg.To.Add(new MailAddress(emailAddress));
            msg.IsBodyHtml = true;
            msg.Subject = "Something interesting for you";
            msg.Body ="Adres URL:" + model.ImgURL + "\n Opis: \n" + model.Description;

            try
            {
                smtp.Send(msg);
                return "Message send..."+msg.Body.ToString();
            }
            catch (Exception ex)
            {
                string exp = ex.ToString();
                return "Mail Not Sent ... and ther error is " + exp;
            }
        }
    }
}
