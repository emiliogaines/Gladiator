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
        public static readonly string[] EnemyNames = {
            "Gurra Grr", "Shirley Clamp", "Jack the Ripper", "Sid Vicious",
            "Jack The Knife", "Hannibal", "Deathwing","The Lich King", "Polar Bear","Zombie", "Angry Pigeon",
            "Mad Bee", "Confused Seagull","Ragnaros","Mr. Bean","Sherlock Golmes"};
        




        public Enemy(String enemyName, int round)
        {
            int level = 1 + (round / 3);
            name = enemyName;
            baseHealth = random.Next(10,21);
            baseStrength = random.Next(3,6);

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
