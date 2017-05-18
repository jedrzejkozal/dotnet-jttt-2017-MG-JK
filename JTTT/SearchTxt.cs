using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class SearchTxt : Action
    {
        public override EmailModel prepareEmail(string arg1, string arg2)
        {
            return new EmailModel();
        }
    }
}
