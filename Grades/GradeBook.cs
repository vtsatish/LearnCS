using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeAbstract
    {
        public event NameChangedDelegate NameChanged;
        public GradeBook()
        {
            GradeName = this.GetHashCode().ToString();
            gradelList = new List<float>();
            NameChanged += OnNameChanged;
            NameChanged += OnChanged;
        }
        ~GradeBook()
        {
            NameChanged = null;
        }
        public override string getGradeName()
        {
            return this.GradeName;
        }
        public override void setGradeName(string inputname)
        {
            if (GradeName != inputname)
            {
                NameChangedEventArgs args = new NameChangedEventArgs();
                args.ExistingString = GradeName;
                args.NewString = inputname;
                NameChanged(this, args);
            }
            GradeName = inputname;

        }
        public override void AddGrade(float sendGrade)
        {
            Console.WriteLine("Base Class AddGrade");
            gradelList.Add(sendGrade);
            jt = JobType.hourly;
        }
        public override void AllocateParams(params int[] intparams)
        {
            locintarray = new int[intparams.Length];
            locintarray = intparams;
            Console.WriteLine(locintarray.Length);
        }

        void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Book name Changing from" + args.ExistingString + "to" + args.NewString);
        }

        void OnChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Multiple delegates to same delgated method variable");
        }

        public override IEnumerator GetEnumerator()
        {
            return gradelList.GetEnumerator();
        }
    }
}
