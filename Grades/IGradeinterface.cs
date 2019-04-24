using System.Collections;
using System.Collections.Generic;

namespace Grades
{
    public interface IGradeinterface : IEnumerable
    {
        List<float> gradelList { get; set; }
        void AllocateParams(params int[] intparams);
        void AddGrade(float f);
        string getGradeName();
        void setGradeName(string inputname);
    }
}