using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace com.LearnXunitTest
{
    public class XunitTest
    {
        [Fact]
        [Trait ("category","smoke")]
        [Trait("priority", "p0")]
        public void MyTestMethod()
        {
            String testStr = "New String";
            System.Threading.Thread.Sleep(2000);
            Xunit.Assert.Equal(testStr, testStr);
        }

        [Fact]
        [Trait("priority", "p1")]
        [Trait("category", "sanity")]
        public void NewTestMethod()
        {
            String testStr = "New String";
            System.Threading.Thread.Sleep(2000);
            Xunit.Assert.NotEqual("wrong", testStr);
        }
    }
}
