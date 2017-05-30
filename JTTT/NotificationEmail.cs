using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;

namespace JTTT
{
    public class NotificationEmail : NotificationMethod
    {
        private Log log;
        private SmtpClient smtp;

        public NotificationEmail(Log _log)
        {
            log = _log;

            smtp = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jttt.net@gmail.com", "haslo1234"),
                Host = "smtp.gmail.com"
            };
        }

        public override string notify(DataModel arg, BindingList<Tuple<DataModel, Action, NotificationMethod>> list)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("jttt.net@gmail.com");
            msg.To.Add(new MailAddress(arg.adress));
            msg.IsBodyHtml = true;
            msg.Subject = "Something interesting for you";

            var iter = 0;

            foreach (var element in list)
            {
                iter++;
                msg.Body += "Adres URL:<br> <img src =\"" + element.Item1.ImgURL + "\" alt = \"tekst alternatywny\"/> <br>Opis: <br>" + element.Item1.Description + "<br><br>";
            }
            
            try
            {
                log.logNotification("Wyslij maila", arg, "Message send");
                smtp.Send(msg);
                return iter + "Message send..." + msg.Body.ToString();
            }
            catch (Exception ex)
            {
                log.logNotification("Wyslij maila", arg, "Mail Not Sent " + ex.ToString() );
                string exp = ex.ToString();
                return "Mail Not Sent ... and ther error is " + exp;
            }
        }
    }
}
