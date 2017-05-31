﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;

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

        public override string notify(BindingList<Tuple<DataModel, Action, NotificationMethod>> list)
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

            foreach (var element in list)
            {
                WebClient webClient = new WebClient();

                try
                {
                    webClient.DownloadFile(element.Item1.ImgURL, "temp.png");
                }
                catch (WebException e)
                {
                    retval += e;
                }

                MailMessage msg = new MailMessage();
                msg.Attachments.Add(new Attachment("temp.png"));
                msg.From = new MailAddress("jttt.net@gmail.com");
                msg.To.Add(new MailAddress(element.Item1.adress));
                msg.IsBodyHtml = true;
                msg.Subject = "Something interesting for you";
                msg.Body = "Opis: " + element.Item1.Description;

                email.Add(element.Item1.adress);

                try
                {
                    log.logNotification("Wyslij maila", element.Item1, "Message send");
                    smtp.Send(msg);
                    retval += "Message send..." + element.Item1.adress + msg.Body.ToString();
                }
                catch (Exception ex)
                {
                    log.logNotification("Wyslij maila", element.Item1, "Mail Not Sent " + ex.ToString());
                    string exp = ex.ToString();
                    retval += "Mail Not Sent ... and ther error is " + exp;
                }
            }

            return retval;
        }
    }
}
