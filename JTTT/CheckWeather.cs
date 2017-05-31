using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //conection to web page
using System.IO;  //Stream and Stream reader

namespace JTTT
{
    [Serializable]
    public class CheckWeather : Action
    {
        private Log log;

        public CheckWeather(Log _log)
        {
            log = _log;
        }

        public override string ToString()
        {
            return "CheckWeather".ToString();
        }

        public override DataModel prepareEmail(string arg1, string arg2, string arg3)
        {
            try
            {
                DataModel email = new DataModel();

                email.ImgURL = " http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate=" + arg1 + "12&row=436&col=181&lang=pl";
                email.Description = "Pogoda dla Wrocławia w dniu " + arg1;
                email.adress = arg3;

                log.logAction("Sprawdź pogodę we Wrocławiu", email);

                return email;
            }
            catch (System.ArgumentException exception)
            {
                throw exception;
            }
        }
    }
}
