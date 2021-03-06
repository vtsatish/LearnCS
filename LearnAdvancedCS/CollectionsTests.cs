﻿using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace LearnAdvancedCS
{
    public class CollectionsTests
    {
        [Fact]
        [Trait("category", "smoke")]
        [Trait("priority", "p0")]
        public void ListTestMthod()
        {
            List<Employee> eList = new List<Employee>
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
                }
            };
            Employee newemp = new Employee { Name = "Addedentry", EmpId = 4231 };
            eList.Add(newemp);
            Assert.Equal(3, eList.Count);
            eList.RemoveAt(0);
            Assert.Equal(2, eList.Count);
            Assert.Contains(newemp, eList);
            Assert.Equal(124, eList[0].EmpId);
            eList.Add(newemp);
            Assert.Equal(3, eList.Count);
        }
        [Fact]
        public void QueueTestMethod()
        {
            Queue<int> eQueue = new Queue<int>();
            eQueue.Enqueue(1);
            eQueue.Enqueue(2);
            eQueue.Enqueue(3);

            Assert.NotEqual(3, eQueue.Peek());
            Assert.Equal(1,eQueue.Dequeue());
            Assert.Equal(2, eQueue.Peek());
            Assert.NotEmpty(eQueue);

        }

        [Fact]
        public void StackTestMethod()
        {
            Stack<string> eStack = new Stack<string>();
            eStack.Push("Hello");
            eStack.Push("New");
            eStack.Push("test");

            Assert.NotEqual(4, eStack.Count);
            eStack.Pop();
            Assert.Equal("New", eStack.Peek());
            Assert.Equal(2, eStack.Count);
        }
    }
}
