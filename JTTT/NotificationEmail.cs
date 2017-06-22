using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace JTTT
{
    [Serializable]
    public class NotificationEmail : NotificationMethod
    {
        private Log log;
        private List<string> email;

        public NotificationEmail(Log _log)
        {
            log = _log;
            email = new List<string>();
        }

        public override string ToString()
        {
            String retval = null;
            foreach (var element in email)
            {
                retval += "Email " + element;
            }
            return retval;
        }

        public override string getType()
        {
            return "Email".ToString();
        }

        public override string notify(DataModel data_model)
        {
            string retval = null;

            SmtpClient smtp = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jttt.net@gmail.com", "haslo1234"),
                Host = "smtp.gmail.com"
            };

                WebClient webClient = new WebClient();
                var imgPath = Path.GetTempFileName().Replace(".tmp", ".jpg");

                try
                {
                    webClient.DownloadFile(data_model.ImgURL, imgPath);
                }
                catch (WebException e)
                {
                    retval += e;
                }

                MailMessage msg = new MailMessage();
                msg.Attachments.Add(new Attachment(imgPath));
                msg.From = new MailAddress("jttt.net@gmail.com");

                msg.To.Add(new MailAddress(data_model.address)); //throws System.FormatException

                msg.IsBodyHtml = true;
                msg.Subject = "Something interesting for you";
                msg.Body = "Opis: " + data_model.Description;
                log.logDebug("Notification email", data_model.address);

                email.Add(data_model.address);

                try
                {
                    log.logNotification("Wyslij maila", data_model, "Message send");
                    smtp.Send(msg);
                    retval += "Message send..." + data_model.address + msg.Body.ToString();
                }
                catch (Exception ex)
                {
                    log.logNotification("Wyslij maila", data_model, "Mail Not Sent " + ex.ToString());
                    string exp = ex.ToString();
                    retval += "Mail Not Sent ... and ther error is " + exp;
                }

            return retval;
        }
    }
}
