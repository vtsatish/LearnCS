using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Linq;
using System.Collections;

namespace LearnCollections
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Test Started...");
            WordCount("hello how are you");
            WordCount("hi hi hi hi");
            int[] numlist = new int[] { 4, 3, 2, 3, 4, 5, 4, 3, 2, 1, -1, 1, 2, 3, 4, 5 };
            SearchArray(numlist, 5);
            Thread.Sleep(3000);

        }

        private static void SearchArray(int[] numlist, int v)
        {
            
        }

        public void TestList()
        {

        }

        public static void WordCount(String Sentence)
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

            IDictionaryEnumerator dictiterator = mydict.GetEnumerator();

            foreach(String str in mydict.Keys)
            {
                Console.WriteLine("\nString " + str + " occured " + mydict[str] + "times\n");
            }
            

        }
    }
}