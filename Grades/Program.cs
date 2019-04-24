using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            IGradeinterface bookOne = new ThrowAwayGradeBook();
            bookOne.AddGrade(10.8f);
            PrintStats(bookOne);

            GradeBook bookTwo = new GradeBook();
            AddGrade(bookTwo);

            Console.WriteLine(GradeAbstract.maxGrade);

            //System.Threading.Thread.Sleep(2000);
            PrintStats(bookTwo);

            /*SpeechSynthesizer sz = new SpeechSynthesizer();
            sz.Speak("Sum of the grades = " + gs.SumGrade);*/

            bookOne.AllocateParams(20, 30);
            SetGrade(bookOne, bookTwo);
            FileBookName(bookOne);

            Console.WriteLine("I am back running... :-)");

            foreach(float grd in bookOne)
            {
                Console.WriteLine(grd);
            }

        }

        private static void FileBookName(IGradeinterface bookOne)
        {
            StreamWriter fout = File.CreateText("fileout.txt");
            try
            {
                fout.WriteLine(bookOne.getGradeName() + bookOne.GetHashCode().ToString());
            }
            finally
            {
                fout.Close();
            }
        }

        private static void SetGrade(IGradeinterface bookOne, IGradeinterface bookTwo)
        {
            try
            {
                bookOne.setGradeName("First grade book");
                bookTwo.setGradeName("New grade book");
                bookOne.setGradeName("Again First book");
                Console.WriteLine(bookOne.getGradeName());
                //bookTwo.setGradeName(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("After exceptions if any.....");
            }
        }

        private static void PrintStats(IGradeinterface bookTwo)
        {
            GradeStats gs = new GradeStats(bookTwo);
            Console.WriteLine("List of the grades in " + bookTwo + ":");
            //bookTwo = bookOne;
            gs.ComputeStats();

            Console.WriteLine("Sum of the grades = " + gs.SumGrade);
            Console.WriteLine("Avg of the grades = " + gs.AverageGrade);
            Console.WriteLine("Max of the grades = " + gs.MaxGrade);
            Console.WriteLine("Min of the grades = " + gs.MinGrade);
            Console.WriteLine("Grade Letter is :" + gs.LetterGrade);
        }

        private static void AddGrade(IGradeinterface bookTwo)
        {
            bookTwo.AddGrade(70);
            bookTwo.AddGrade(80);
            bookTwo.AddGrade(90);
        }
    }

}
