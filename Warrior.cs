using WarriorWars.Equipment;
using WarriorWars.Enum;
using System;
using System.Threading;

namespace WarriorWars
{
    class Warrior
    {

        private const int GOOD_GUY_STARTING_HEALTH = 20;
        private const int BAD_GUY_STARTING_HEALTH = 20;

        // this is an enum
        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive {
            get
            {
                return isAlive;
            } 
        }

        // these are other classes
        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;

            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void AttackResult(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfulWriteLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfulWriteLine($"{name} is victorious!!", ConsoleColor.Green);
            } else
            {
                Console.WriteLine($"{name} attacked {enemy.name} for {damage} hit points. {enemy.name} has {enemy.health} remaining.");
                Console.WriteLine("---------------------------------------------------------------------");
            }

            Thread.Sleep(200);
        }
    }
}
