using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //conection to web page
using System.IO;  //Stream and Stream reader

namespace JTTT
{
    public class CheckWeather : Action
    {
        public CheckWeather()
        {
        }
        
        public override DataModel prepareEmail(string arg1, string arg2)
        {
            try
            {
                DataModel email = new DataModel();

                email.ImgURL = " http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate=" + arg1 + "12&row=436&col=181&lang=pl";
                email.Description = "Pogoda dla Wrocławia w dniu " + arg1;

                return email;
            }
            catch (System.ArgumentException exception)
            {
                throw exception;
            }
        }
    }
}
