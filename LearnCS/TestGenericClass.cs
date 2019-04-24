using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using com.LearnCS;

namespace LearnCS
{
    public class TestGenericClass
    {
        [Fact]
        [Trait("category", "smoke")]
        [Trait("priority", "p0")]
        public void AddtoGenericClassTest()
        {
            GenericsClass<int> testObject= new GenericsClass<int>(3);
            testObject.WriteMethod(2);
            testObject.WriteMethod(5);
            Assert.Equal(2,testObject.Position());
            Assert.Equal(5, testObject.ReadMethod(2));
        }
        [Fact]
        [Trait("category", "sanity")]
        [Trait("priority", "p1")]
        public void NegtaiveTest()
        {
            GenericsClass<int> testObject = new GenericsClass<int>(3);
            Assert.NotEqual(2, testObject.Position());
            Assert.Equal(0,testObject.ReadMethod(4));
        }

        [Fact]
        public void StringTest()
        {
            GenericsClass<String> testObject = new GenericsClass<String>(3);
            testObject.WriteMethod("Hello");
            Assert.NotEqual(2, testObject.Position());
            testObject.WriteMethod("Good");
            Assert.Equal(2, testObject.Position());
            Assert.NotEqual("Hi", testObject.ReadMethod(1));
        }

        [Fact]
        public void ObjectTest()
        {
            GenericsClass<TestClassLearn> testObject = new GenericsClass<TestClassLearn>(1);
            TestClassLearn classobj = new TestClassLearn();
            testObject.WriteMethod(classobj);
            Assert.Equal(1, testObject.Position());
            Assert.Equal(100, testObject.ReadMethod(1).GetMeNumber(10));
        }
    }
}
