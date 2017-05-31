using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class SearchTxt : Action
    {
        public override DataModel prepareEmail(string arg1, string arg2, string arg3)
        {
            return new DataModel();
        }

        public override string ToString()
        {
            return "SearchTxt".ToString();
        }
    }
}
