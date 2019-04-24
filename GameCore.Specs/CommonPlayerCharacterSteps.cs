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
    class CommonPlayerCharacterSteps : Steps
    {
        private PlayerCharacterStepsContext _context;
        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext contextnew)
        {
            _context = contextnew;
        }

        [Given(@"I am a new player (.*)")]
        public void GivenIAmANewPlayer(string playername)
        {
            _context.Player = new PlayerCharacter(playername);
            this.ScenarioContext.Set(_context.Player, "Player");
        }
    }
}
