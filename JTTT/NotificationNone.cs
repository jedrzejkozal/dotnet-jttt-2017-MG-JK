﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class NotificationNone : NotificationMethod
    {
        public override string notify(BindingList<Tuple<DataModel, Action, NotificationMethod>> list)
        {
            System.ArgumentException ex = new System.ArgumentException("Wybierz sposób powiadomienia!");
            throw ex;
        }

        public override string ToString()
        {
            return "".ToString();
        }
    }
}
