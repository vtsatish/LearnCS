using System;

namespace Grades
{
    public class GradeStats
    {
        public float SumGrade=0;
        public float AverageGrade;
        public float MaxGrade = 0;
        public float MinGrade = float.MaxValue;
        public IGradeinterface gb;

        public GradeStats(IGradeinterface gb)
        {
            this.gb = gb;
        }
        public void ComputeStats()
        {
            foreach (float gradeitem in this.gb.gradelList)
            {
                Console.WriteLine(gradeitem);
                SumGrade += gradeitem;
                MaxGrade = Math.Max(gradeitem, MaxGrade);
                MinGrade = Math.Min(gradeitem, MinGrade);
            }
                AverageGrade = SumGrade / this.gb.gradelList.Count;
            
        }

        public string LetterGrade
        {
            
            get
            {
                string result;
                if (AverageGrade >= 90)
                {

                    result= "A";
                }
                else if(AverageGrade >= 80)
                {
                    result = "B";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
    }
}