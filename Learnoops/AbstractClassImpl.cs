using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnoops
{
    public abstract class AbstractClassImpl
    {
        public int num;
        public string str;
        public abstract bool evaluate();
    }

    public class ActualImpl : AbstractClassImpl
    {
        public override bool evaluate()
        {
            if ((num != 0) && (str != null))
            {
                return true;
            }
            else return false;

        }

    }
}
