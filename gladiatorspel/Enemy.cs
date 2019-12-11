using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Enemy
    {
        readonly Random random = new Random();

        public string name;
        public int baseHealth, health;
        public int baseStrength, strength;
        public int AttackDamage { get; set; }
        private readonly string[] EnemyNames = { "Gurra Grr", "Shirley Clamp", "Jack the Ripper", "Sid Vicious",
            "Jack The Knife", "Hannibal", "Deathwing","The Lich King", "Polar Bear","Zombie", "Angry Pigeon",
            "Mad Bee", "Confused Seagull","Ragnaros","Mr. Bean","Sherlock Golmes"};




        public Enemy(int round)
        {
            int level = 1 + (round / 3);
            name = EnemyNames[random.Next(EnemyNames.Length)];
<<<<<<< HEAD
            baseHealth = random.Next(10, 21);
            baseStrength = random.Next(1, 4);
=======
            baseHealth = random.Next(10,21);
            baseStrength = random.Next(3,6);
>>>>>>> 33f638d796f3884918c2d530c8c70d597431e007

            health = baseHealth * level;
            strength = baseStrength * level;
        }

        public int Attack(Gladiator player)
        {
            //Console.WriteLine("--------------------");
            //Console.WriteLine("{0} attacks!", name);
            AttackDamage = strength;
            //Console.WriteLine("{0} dealt {1} damage to you.",name, AttackDamage);
            //Console.WriteLine("--------------------");
            player.dealDamage(AttackDamage);
            return AttackDamage;

        }
        public Item DropItem()
        {
            Item droppedItem = (Item.ListOfItems[random.Next(Item.ListOfItems.Length)]);
            return droppedItem;

        }
    }
}
