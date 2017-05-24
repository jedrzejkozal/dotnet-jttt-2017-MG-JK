using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; //conection to web page
using System.IO;  //Stream and Stream reader
using HtmlAgilityPack; //parse html

namespace JTTT
{
    public class SearchImageWebSite : Action
    {
        public SearchImageWebSite()
        {
            Label1Text = "Podaj adres URL:";
            Label2Text = "Podaj szukany tag";
            Label3Text = "Podaj maila:";
            isTextBox1Visible = true;
            isTextBox2Visible = true;
        }

        public override EmailModel prepareEmail(string arg1, string arg2)
        {
            try
            {
                EmailModel email = new EmailModel();
                WebClient client = new WebClient();
                Stream data = client.OpenRead(arg1);
                StreamReader reader = new StreamReader(data);
                string site = reader.ReadToEnd();

                //search for images in html
                var doc = new HtmlAgilityPack.HtmlDocument();
                var pageHtml = site;
                doc.LoadHtml(pageHtml);
                var nodes = doc.DocumentNode.Descendants("img");
                foreach (var node in nodes)
                {
                    if (node.GetAttributeValue("alt", "").Contains(arg2) && node.GetAttributeValue("src", "").Contains("http"))
                    {

                        email.ImgURL = node.GetAttributeValue("src", "");
                        email.Description = node.GetAttributeValue("alt", "");
                    }
                }
                return email;
            }
            catch (System.ArgumentException exception)
            {
                throw exception;
            }
        }
    }
}
