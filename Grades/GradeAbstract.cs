using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeAbstract : IGradeinterface
    {
        public List<float> gradelList { get; set; }
        public static float maxGrade = 100;
        protected int[] locintarray;
        public enum JobType
        {
            salary = 1,
            contractor,
            hourly,
            consultant = 25
        }
        public JobType jt = JobType.salary;
        protected string _gradename;
        protected const int scoreSize = 5;
        public int[] scores = new int[scoreSize];
        public int TotalScore = 0;
        public abstract IEnumerator GetEnumerator();
        public string GradeName
        {
            get
            {
                return _gradename;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Not empty" + value);
                    _gradename = value;
                }
                else
                {
                    throw new Exception("Zero not allowed");
                }
            }
        }
        public abstract void AllocateParams(params int[] intparams);
        public abstract void AddGrade(float f);
        public abstract string getGradeName();
        public abstract void setGradeName(string inputname);
        public virtual void CalculateTotalScore()
        {
            TotalScore = 0;
            foreach (int scoreitem in scores)
            {
                TotalScore = TotalScore + scoreitem;
            }
        }
        public virtual void IncrementScore()
        {
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = scores[i] + 10;
            }
        }
    }
}
