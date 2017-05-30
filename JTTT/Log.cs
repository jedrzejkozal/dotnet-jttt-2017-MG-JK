using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Log
    {
        private string fileName;

        public Log(string _fileName)
        {
            fileName = _fileName;

            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        public void logAction(string action, DataModel content)
        {
            if (File.Exists(fileName))
            {
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine("Czas " + DateTime.Now);
                sw.WriteLine("Akcja " + action);
                sw.WriteLine("Zawartość " + content.ImgURL + " " + content.Description);
                sw.WriteLine();
                sw.Close();
            }
        }

        public void logNotification(string action, DataModel content, string result)
        {
            if (File.Exists(fileName))
            {
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine("Czas " + DateTime.Now);
                sw.WriteLine("Akcja " + action);
                sw.WriteLine("Adres " + content.adress);
                sw.WriteLine("Rezultat " + result);
                sw.WriteLine();
                sw.Close();
            }
        }
    }
}
