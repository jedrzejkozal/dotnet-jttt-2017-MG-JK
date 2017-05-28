using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    /*Base class for other actions*/
    public class Action
    {
        public virtual DataModel prepareEmail(string arg1, string arg2) { return new DataModel(); }
    }
}
