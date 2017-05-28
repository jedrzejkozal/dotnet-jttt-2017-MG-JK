using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class NotificationNone : NotificationMethod
    {
        public override string notify(DataModel arg)
        {
            System.ArgumentException ex = new System.ArgumentException("Wybierz sposób powiadomienia!");
            throw ex;
        }
    }
}
