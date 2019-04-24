﻿using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace LearnCollections
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
            eList.Add(new Employee { Name = "Addedentry", EmpId = 4231 });
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
            Assert.NotEmpty(eQueue);

        }
    }
}
