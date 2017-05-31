using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    class ActionNone : Action
    {
        public ActionNone()
        {
        }

        public override DataModel prepareEmail(string arg1, string arg2, string arg3)
        {
            System.ArgumentException ex = new System.ArgumentException("Wybierz akcję!");
            throw ex;
        }

        public override string ToString()
        {
            return "".ToString();
        }
    }
}
