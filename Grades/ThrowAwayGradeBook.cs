using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override void AddGrade(float sendGrade)
        {
            Console.WriteLine("Derived Class AddGrade");
            gradelList.Add(sendGrade+10);
            jt = JobType.consultant;
        }
    }
}
