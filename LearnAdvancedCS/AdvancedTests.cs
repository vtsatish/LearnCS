using System;
using System.Collections.Generic;
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
            var delegatorObject = new Delegator();
            var calleeObject = new Callee("Hello");
            Action<string> adg = calleeObject.ReplaceImage;
            delegatorObject.ActionProcess("Change", adg);
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
                    Name = "Jamesnew",
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
        }

    }
}
