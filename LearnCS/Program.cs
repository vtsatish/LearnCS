using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.LearnCS
{
    class Program
    {

        static void Main(string[] args)
        {
            int retInt;
            String retString;
            int conint;
            Console.WriteLine("Test started" + args[0]);
            System.Threading.Thread.Sleep(2000);
            TestClassLearn tcl = new TestClassLearn();
            retInt = tcl.GetMeNumber(20);
            retString = tcl.GetMeString("hello");
            conint = int.Parse("100");
            if (retInt > 100)
            {
                Console.WriteLine(retInt + "is greater than 100");
            }
            else
            {
                Console.WriteLine(retInt + "is NOT greater than 100");
            }
            Console.WriteLine(retString);
            Console.WriteLine("The string converted to int is " + conint);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
