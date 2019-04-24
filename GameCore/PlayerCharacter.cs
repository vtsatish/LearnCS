using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class PlayerCharacter
    {
        public PlayerCharacter(string givenplayername)
        {
            PlayerName = givenplayername;
        }
        public void Hit(int damage)
        {
            var raceSpecfifcDamageResistance = 0;

            if (Race == "Elf")
            {
                raceSpecfifcDamageResistance = 20;
            }

            var totalDamageTaken =
                Math.Max(damage - raceSpecfifcDamageResistance - DamageResistance, 0);


            if (Health >= totalDamageTaken)
            {
                Health -= totalDamageTaken;
            }
            else
            {
                Health = 0;
            }


            if (Health <= 0)
            {
                IsDead = true;
            }
        }

        public int DamageResistance { get; set; }
        public string Race { get; set; }

        public static string safeString= "safe";

        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public string PlayerName { get; set; }

        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public CharacterENUM CharacterENUMobj { get; set; }
        public DateTime LastSleepTime { get; set; }

        public int WeaponsValue
        {
            get { return Weapons.Sum(x => x.Value); }
        }
        public int MagicalPower
        {
            get { return MagicalItems.Sum(x => x.Power); }
        }
        public int WeaponValueForName(string locweaponName)
        {
            int weaponValue = -1;
            foreach(var locweapon in Weapons)
            {
                if (locweapon.Name.Equals(locweaponName))
                {
                    return locweapon.Value;
                }
            }
            return weaponValue;
        }
        public void CastHealingSpell()
        {
            if(CharacterENUMobj == CharacterENUM.Healer)
            {
                this.Health = 100;
            }
            else
            {
                this.Health += 10;
            }
        }
        public void ReadHealthSleep()
        {
            var dayssincelastslept = DateTime.Now.Subtract(LastSleepTime).Days;
            if (dayssincelastslept <= 2)
            {
                this.Health = 100;
            }
        }

        public void UseMagicalItem(string itemName)
        {
            int powerReduction = 10;

            if (Race == "Elf")
            {
                powerReduction = 0;
            }

            var itemToReduce = MagicalItems.Find(item => item.Name == itemName);

            itemToReduce.Power -= powerReduction;
        }
        public void Hit(string v)
        {
            switch (v)
            {
                case "gun":
                    this.Hit(40);
                    break;
                case "knife":
                    this.Hit(30);
                    break;
                default:
                    this.Hit(10);
                    break;

            }
        }
    }
}