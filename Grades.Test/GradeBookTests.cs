using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;


namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestCategory("Nightly"),TestMethod(),Priority(0)]
        public void VerifyStats()
        {
            GradeBook gbook = new GradeBook();
            gbook.AddGrade(20);

            GradeBook newBook = new GradeBook();
            newBook = gbook;
            GradeStats gstats = new GradeStats(gbook);
            gstats.ComputeStats();
            Assert.AreEqual(gstats.SumGrade, 20);
            Assert.AreEqual(gbook.gradelList, newBook.gradelList);
        }

        [TestMethod]
        public void VerifyTypes()
        {
            int x1 = 100;
            Int32 x2 = x1;
            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void Verifyenums()
        {
            GradeBook gbook = new GradeBook();
            gbook.AddGrade(20);

            GradeBook newBook = new GradeBook();
            Assert.AreNotEqual(gbook.jt,newBook.jt);
        }

        [TestMethod]
        public void VerifyScores()
        {
            GradeBook gbook = new GradeBook();
            gbook.AddGrade(20);
            gbook.AddGrade(40);
            gbook.AddGrade(60);
            gbook.AddGrade(70);
            GradeBook newBook = new GradeBook();

            gbook.IncrementScore();
            gbook.CalculateTotalScore();
            Assert.AreNotEqual(gbook.TotalScore, newBook.TotalScore);
            newBook.IncrementScore();
            newBook.CalculateTotalScore();
            Assert.AreEqual(gbook.TotalScore, newBook.TotalScore);
        }


    }
}
