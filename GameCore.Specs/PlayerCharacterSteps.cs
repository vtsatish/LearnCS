using System;
using System.Data;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit.Abstractions;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps : Steps
    {
        private PlayerCharacterStepsContext _context;
        public PlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }
     
        [When(@"I get (.*) damage")]
        public void WhenIGetDamage(int p0)
        {
            _context.Player.Hit(p0);
        }

        [When(@"I get (.*) damage")]
        [Scope(Tag = "elftests")]
        public void WhenIGetDamageAsAnElf(int p0)
        {
            _context.Player.Hit(p0);
        }

        [Then(@"my health should be (.*)")]
        public void ThenMyHealthShouldBe(int p0)
        {
            Xunit.Assert.Equal(p0, _context.Player.Health);
        }

        [Then(@"my health should not be (.*)")]
        public void ThenMyHealthShouldNotBe(int p0)
        {
            Xunit.Assert.NotEqual(p0, _context.Player.Health);
        }

        [Then(@"player is dead")]
        public void ThenPlayerIsDead()
        {
            Xunit.Assert.True(_context.Player.IsDead);
        }

        [When(@"I get hit with the following weapons:")]
        public void WhenIGetHitWith(Table table)
        {
            foreach(var rowitem in table.Rows)
            {
                _context.Player.Hit(rowitem["weapon"]);
            }
        }

        [Given(@"My Character is set as (.*)")]
        public void GivenMyCharacterIsSetAs(CharacterENUM character)
        {
            _context.Player.CharacterENUMobj = character;
            PlayerCharacter.safeString = "Healer";
        }

        [When(@"I get the HealingSpell")]
        public void WhenIGetTheHealingSpell()
        {
            _context.Player.CastHealingSpell();
        }


        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];

            var attributes = table.CreateInstance<PlayerAttributes>();

            //dynamic attributes = table.CreateDynamicInstance();
            _context.Player.Race = attributes.Race;
            _context.Player.DamageResistance = attributes.Resistance;

        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            //foreach (var row in table.Rows)
            //{
            //    var name = row["name"];
            //    var value = row["value"];
            //    var power = row["power"];

            //    _context.Player.MagicalItems.Add(new MagicalItem
            //    {
            //        Name = name,
            //        Value = int.Parse(value),
            //        Power = int.Parse(power)
            //    });
            //}

            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();
            _context.Player.MagicalItems.AddRange(items);
            //_context.Player.MagicalItems = items.ToList<MagicalItem>();




        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int p0)
        {
            Xunit.Assert.Equal(p0, _context.Player.MagicalPower);
        }


        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastslept)
        {
            _context.Player.LastSleepTime = lastslept;
        }

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()
        {
            _context.Player.ReadHealthSleep();
        }

        [Given(@"I get the below weapon")]
        public void GivenIGetTheBelowWeapon(Weapon singleweapon)
        {
            _context.Player.Weapons.Add(singleweapon);
        }


        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons)
        {
            _context.Player.Weapons.AddRange(weapons);
        }

        [Then(@"My weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int p0)
        {
            Xunit.Assert.Equal(_context.Player.WeaponsValue, p0);
        }


        [Given(@"I belong to (.*) Race")]
        public void GivenIMAnElf(String race)
        {
            _context.Player.Race = race;
        }

        [Given(@"I have an (.*) with a power of (.*)")]
        public void GivenIHaveAMagicalItemWithAPowerOf(string magicalitemName, int itemPower)
        {
            _context.Player.MagicalItems.Add(
                new MagicalItem
                {
                    Name = magicalitemName,
                    Power = itemPower,
                    Value = 20
                });

            _context.FullgMagicalPower += itemPower;
        }

        [When(@"I use a magical (.*)")]
        public void WhenIUseAMagical(string magicalitemName)
        {
            _context.Player.UseMagicalItem(magicalitemName);
        }

        [Then(@"The magical power is reduced (.*)")]
        public void ThenThemagicalPowerReduced(bool boolValue)
        {
            if(boolValue is true)
            {
                Xunit.Assert.NotEqual(_context.FullgMagicalPower,
                    _context.Player.MagicalPower);
            }
            else
            {
                Xunit.Assert.Equal(_context.FullgMagicalPower,
                    _context.Player.MagicalPower);
            }

            
        }

        [Then(@"my safestring is (.*)")]
        public void ThenMySafestringIsHealer(string checksafe)
        {
            Xunit.Assert.Equal(checksafe, PlayerCharacter.safeString);
        }



    }
}
