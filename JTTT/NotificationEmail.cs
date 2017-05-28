using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace JTTT
{
    public class NotificationEmail : NotificationMethod
    {
        public override string notify(DataModel arg)
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

            msg.To.Add(new MailAddress(arg.adress));
            msg.IsBodyHtml = true;
            msg.Subject = "Something interesting for you";
            msg.Body = "Adres URL:<br> <img src =\"" + arg.ImgURL + "\" alt = \"tekst alternatywny\"/> <br>Opis: <br>" + arg.Description;
            try
            {
                smtp.Send(msg);
                return "Message send..." + msg.Body.ToString();
            }
            catch (Exception ex)
            {
                string exp = ex.ToString();
                return "Mail Not Sent ... and ther error is " + exp;
            }
        }
    }
}
