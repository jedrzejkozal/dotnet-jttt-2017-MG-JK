﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class NotificationMethod
    {
        public virtual string notify(BindingList<Tuple<DataModel, Action, NotificationMethod>> list) { /*string a = "base"; return a;*/ return null; }

        public override string ToString()
        {
            return "".ToString();
        }
    }
}
