using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    /*Base class for other actions*/

    [Serializable]
    public class Action
    {
        public virtual DataModel prepareEmail(string arg1, string arg2, string arg3) { return new DataModel(); }

        public override string ToString()
        {
            return "".ToString();
        }
    }
}
