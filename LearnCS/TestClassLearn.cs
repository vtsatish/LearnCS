using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.LearnCS
{
    public class TestClassLearn
    {
        public TestClassLearn()
        {
            Console.WriteLine("My first constructor");
        }
        public int GetMeNumber(int testint)
        {
            return testint * 10;
        }
        public String GetMeString(String teststr)
        {
            return teststr + " added buddy";
        }
    }
}
