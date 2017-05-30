using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class NotificationMethod
    {
        public virtual string notify(DataModel arg, BindingList<Tuple<DataModel, Action, NotificationMethod>> list) { /*string a = "base"; return a;*/ return null; }
    }
}
