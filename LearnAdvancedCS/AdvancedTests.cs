using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace LearnAdvancedCS
{
    public class AdvancedTests
    {
        [Fact]
        public void ExceptionTest()
        {

        }
        [Fact]
        public void DelegatesTest()
        {
            var delegatorObject = new Delegator();
            var calleeObject = new Callee("Hello");
            Delegator.ImageDelegator imgd = calleeObject.DoubleImage;
            imgd += calleeObject.ReverseImage;
            delegatorObject.Process(imgd);
            Xunit.Assert.NotEqual("HelloHello", calleeObject.GetImage());

        }
        [Fact]
        public void ActionDelegateTest()
        {
            //var delegatorObject = new Delegator();
            var calleeObject = new Callee("Hello");
            Action<string> adg = calleeObject.ReplaceImage;
            //delegatorObject.ActionProcess("Change", adg);
            adg("Change");
            Xunit.Assert.Equal("Change", calleeObject.GetImage());

        }
        [Fact]
        public void LambdaTest()
        {
            LambdaClasses lc = new LambdaClasses(20);
            Assert.Equal(200, lc.getMultiply(10));
        }
        [Fact]
        public void AdvLambdaTest()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee
                {
                    Name = "James",
                    EmpId = 123
                },
                new Employee
                {
                    Name = "Jane",
                    EmpId = 124
                },
                new Employee
                {
                    Name = "Harry",
                    EmpId = 125
                },
                new Employee
                {
                    Name = "Janenew",
                    EmpId = 90
                }

            };

            var oldEmployees = empList.FindAll(empl => empl.EmpId < 100);
            bool hasOld = oldEmployees.Count > 0 ? true : false;
            Assert.Single(oldEmployees);
            Assert.True(hasOld);

            var newEmployees = empList
                .Where(e => e.EmpId > 100)
                .OrderByDescending(e => e.Name);
            Assert.Equal(3, newEmployees.Count());

            var empNames =
                from e in empList
                where e.EmpId > 0
                orderby e.Name
                select e.Name;
            Assert.Contains("Harry", empNames);

            Assert.Equal(90, empList.Min(e => e.EmpId));
        }
        [Fact]
        public void TestEvents()
        {
            var engVideo = new Video("MI", DateTime.Now);//publisher
            var checkMail = new MailService(); //subscriber1
            var checkMessage = new MessageService(); //subscriber2

            engVideo.VideoEncodedNotification += checkMail.OnVideoEncoded;
            engVideo.VideoEncodedNotification += checkMessage.OnVideoEncoded;

            engVideo.VideoGenericNotification += checkMail.OnGenericEncoded;
            engVideo.VideoGenericNotification += checkMessage.OnGenericEncoded;

            engVideo.Encode();
            Assert.Equal(4, VideoEventArgs.count);
        }
        [Fact]
        public void TestExtension()
        {
            string post = "This is a sentence with many words";
            Xunit.Assert.Equal("This is", post.Shorten(2));
        }
        [Fact]
        public void TestNullable()
        {
            DateTime? newDate = null;

            Assert.Null(newDate);
            
            try
            {
                Debug.WriteLine(newDate.Value);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine("In exception\n\n\n" + ex.Message);
            }

            
            newDate = DateTime.Now;
            Assert.NotNull(newDate);

            
        }

        [Fact(Skip = "specific reason")]
        public void TestExceptions()
        {
            StreamWriter sr = null;


            try
            {
                sr = new StreamWriter(new FileStream("C:\\exception.log", FileMode.OpenOrCreate, FileAccess.ReadWrite));
                throw new Exception("Intentional exception");
            }
            catch (Exception ex)
            {
                throw new DateTimeException("Access of null DateTime", ex);
            }
            finally
            {
                if (sr != null)
                    sr.Dispose();

            }

        }

    }
}
