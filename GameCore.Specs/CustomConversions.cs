using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransform(int daysago)
        {
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysago));
        }

        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponTransform(Table tabledata)
        {
            IEnumerable<Weapon> myweapons = tabledata.CreateSet<Weapon>();
            return myweapons;
        }

        [StepArgumentTransformation]
        public Weapon SingleWeaponTransform(Table singledata)
        {
            return singledata.CreateInstance<Weapon>();
        }
    }
}
