using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAdvancedCS
{
    class LambdaClasses
    {
        int factor;
        public LambdaClasses(int input)
        {
            factor = input;
        }
        public int getMultiply(int num)
        {
            Func<int, int> multiply = number => number * factor;
            return multiply(num);
        }

    }
}
