using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    /*Model i M-V-MV represent only information about data and operations that could be done on them
    Model don't have any aplication logic.
    Can be useful when app uses a database*/

    [Serializable]
    public class DataModel
    {
        public string ImgURL, Description, address;

        public override string ToString()
        {
            return string.Format("URL {0} ADRESS {1}", ImgURL, address);
        }
        public DataModel(string a, string b, string c)
        {
            ImgURL = a;
            Description = b;
            address = c;
        }
        public DataModel() { }
    }
}
