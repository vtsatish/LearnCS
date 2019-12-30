using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.LearnCS
{
    public class Person
    {
        public string Name = "Default Name";
        private DateTime _birthday;
        public DateTime BirthDate
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        public String LastName { get; set; }
        public int Ssid { get; set; }
        public double Age
        {
            get
            {
                var timeSpan = DateTime.Today - BirthDate;
                var years = timeSpan.TotalDays / 365;
                return years;

            }
        }


        public void Introduce(string toperson)
        {
            Console.WriteLine("Hi {0} I am {1}", toperson, Name);
        }

        public static Person Parse(string str)
        {
            var intperson = new Person
            {
                Name = str
            };
            return intperson;
        }
    }

    public class Office
    {
        public int classNum;
        public string className;
        public readonly List<Person> People = new List<Person>();
    }
    class Program
    {

        static void Main(string[] args)
        {

            //Console.WriteLine("Test started" + args[0]);
            System.Threading.Thread.Sleep(2000);

            TestParamsANDObj();

            System.Threading.Thread.Sleep(5000);

            TestConstructorAndMethods();

            TestStaticObjectreturn();

            TestReadOnly();

            System.Threading.Thread.Sleep(5000);


        }

        private static void TestReadOnly()
        {
            Office NewOffice = new Office();
            NewOffice.People.Add(new Person());
            NewOffice.People.Add(new Person());
            NewOffice.People.Add(Person.Parse("emp"));
            try
            {
                Console.WriteLine("\nTotal persons in office = " + NewOffice.People.Count + " and last person is " + NewOffice.People[NewOffice.People.Count - 1].Name);
            }
            catch (Exception)
            {

                Console.WriteLine("Array out of index error");
            }
           
        }

        public static void TestParamsANDObj()
        {
            TestClassLearn newTCL = new TestClassLearn
            {
                Name = "Object Initializer"
            };
            Console.WriteLine("Name is " + newTCL.GetMeName());
            try
            {
                newTCL.UseParams(1, 5, 9, "test", "args");
            }
            catch (Exception)
            {

                Console.WriteLine("Exception occured");
            }
        }

        public static void TestConstructorAndMethods()
        {
            int retInt;
            String retString;
            int conint;

            TestClassLearn tcl = new TestClassLearn("Start Test");
            Console.WriteLine("Second object name is {0}", tcl.Name);

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
            Console.WriteLine("\n nEW COURSE \n");
        }

        public static void TestStaticObjectreturn()
        {
            var personvariable = Person.Parse("JOHN");
            personvariable.BirthDate = new DateTime(2017, 1, 18);
            Console.WriteLine("Age of " + personvariable.Name + " is " + personvariable.Age);
            personvariable.Introduce("Mosh");
        }

    }
}
