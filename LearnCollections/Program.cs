using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Configuration;
using System.Linq;
using System.Collections;
using LearnCS;

namespace LearnCollections
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Test Started...");
            DataProcessingClass dpc = new DataProcessingClass();
            dpc.WordCount("hello hello how are you");
            dpc.WordCount("hi hi hi hi");
            int[] numlist = new int[] { 4, 3, 2, 3, 4, 5, 4, 3, 2, 1, -1, 1, 2, 3, 4, 5 };
            Thread.Sleep(3000);

        }
    }
}