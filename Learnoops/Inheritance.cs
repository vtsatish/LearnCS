using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnoops
{
    public class BaseClass
    {
        private int onlyParent;
        private String _childName;
        protected String ForChildren {
            get {
                return _childName;
            }
            set {
                _childName = value;
            }
        }
        public BaseClass()
        {
            onlyParent = 25;
        }
        public BaseClass(int passNum)
        {
            onlyParent = passNum;
        }

        public int getNum()
        {
            return (onlyParent*-1);
        }
    }

    public class ChildClass : BaseClass
    {
        public ChildClass(String passString)
            : base(100)
        {
            ForChildren = passString;
        }

        public void setName(String passString)
        {
            ForChildren = passString;
        }
        public bool gotName {
            get
            {
                if (ForChildren is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
        }
    }

    public class ComposeClass
    {
        public int outNumber;
        public ComposeClass(int passNum)
        {
            BaseClass newbcls = new BaseClass(passNum);
            outNumber = newbcls.getNum();
        }
    }
}
