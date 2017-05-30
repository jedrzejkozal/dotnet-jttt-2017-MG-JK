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
        private Log log;

        public SearchImageWebSite(Log _log)
        {
            log = _log;
        }

        public override DataModel prepareEmail(string arg1, string arg2)
        {
            try
            {
                DataModel email = new DataModel();
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
                        log.logAction("Szukaj po tagach", email);
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
