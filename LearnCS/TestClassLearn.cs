using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.LearnCS
{
    public class TestClassLearn
    {
        public string Name = "Default";
        public TestClassLearn()
        {
            Console.WriteLine("My constructor");
        }
        public TestClassLearn(string argstr)
            : this()
        {
            this.Name = argstr;
            Console.WriteLine("Another constructor...\n");
        }

        public int GetMeNumber(int testint)
        {
            return testint * 10;
        }
        public void UseParams(params object[] listobjects)
        {
            if (listobjects == null)
                throw new ArgumentNullException("list of objects");
            foreach(object indobj in listobjects)
            {
                Console.WriteLine("Object is " + indobj);
            }
        }
        public string GetMeString(String teststr)
        {
            return teststr + " added buddy";
        }
        public string GetMeName()
        {
            return Name;
        }
    }
}
