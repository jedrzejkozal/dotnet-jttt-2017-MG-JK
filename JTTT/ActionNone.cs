using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class ActionNone : Action
    {
        public ActionNone()
        {
        }

        public override DataModel prepareEmail(string arg1, string arg2)
        {
            System.ArgumentException ex = new System.ArgumentException("Wybierz akcję!");
            throw ex;
        }
    }
}
