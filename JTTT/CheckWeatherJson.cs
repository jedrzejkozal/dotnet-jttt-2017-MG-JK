using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    class CheckWeatherJson : Action
    {
        private Log log;

        public CheckWeatherJson(Log _log)
        {
            log = _log;
        }

        public override string ToString()
        {
            return "CheckWeatherJson".ToString();
        }

        public override DataModel prepareEmail(string arg1, string arg2, string arg3)
        {
            try
            {
                WebClient webClient = new WebClient();
                var json = webClient.DownloadString(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},pl&APPID=15f9322f8f308ab9821ec68167f55c41", arg1));

                var weatherStruct = JsonConvert.DeserializeObject<WeatherJsonStruct>(json);
                DataModel email = new DataModel();

                email.ImgURL = "http://openweathermap.org/img/w/" + weatherStruct.weather[0].icon + ".png";
                email.Description = string.Format("Weather for {0} on {1}. It's {2} Celsius degrees. The sky is {3}"
                    , arg1, DateTime.Now, (weatherStruct.main.temp - 271), weatherStruct.weather[0].main);
                email.address = arg3;

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
