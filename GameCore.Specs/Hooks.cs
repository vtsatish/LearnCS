using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class Hooks : Steps
    {
        [BeforeScenario]
        public void BeforeScenarioMethod()
        {
            PlayerCharacter.safeString = "Before";
        }
        [BeforeScenario]
        [Scope(Tag ="elftests")]
        public void BeforeScenarioExtra()
        {

        }
        [AfterScenario]
        public void AfterScenarioMethod()
        {
            Console.WriteLine("\n\nThis is After Scenario\n\n");
        }
    }
}
