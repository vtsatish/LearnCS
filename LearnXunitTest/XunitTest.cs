using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace com.LearnXunitTest
{
    [TestClass]
    public class XunitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String testStr = "New String";
            System.Threading.Thread.Sleep(2000);
            Xunit.Assert.Equal(testStr, testStr);
        }
    }
}
