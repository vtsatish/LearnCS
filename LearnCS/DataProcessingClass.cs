using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCS
{
    public class DataProcessingClass
    {
        public void WordCount(String Sentence)
        {
            List<String> wordList = Sentence.Split(null).ToList();
            Dictionary<String, int> mydict = new Dictionary<String, int>();

            foreach (String str in wordList)
            {
                Console.WriteLine(str);
                if (mydict.ContainsKey(str))
                {
                    mydict[str] += 1;
                }
                else
                {
                    mydict.Add(str, 1);
                }

            }

            foreach (String str in mydict.Keys)
            {
                Console.WriteLine("\nString " + str + " occured " + mydict[str] + "times\n");
            }


        }
    }
}
