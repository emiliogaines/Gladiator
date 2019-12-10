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
        private readonly string[] EnemyNames = { "GurraGrr", "ShirleyClamp", "MioMinMio", "MaoMinMao", "SidVicious", "JackTheKnife", "Hannibal" };
        
        


        public Enemy(int round)
        {
            int level = 1 + (round / 3);
            name = EnemyNames[random.Next(EnemyNames.Length)];
            baseHealth = random.Next(10,21);
            baseStrength = random.Next(1,4);

            health = baseHealth * level;
            strength = baseStrength * level;
        }

        public void Attack(Gladiator player)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("{0} attacks!", name);
            AttackDamage = strength;
            Console.WriteLine("{0} dealt {1} damage to you.",name, AttackDamage);
            Console.WriteLine("--------------------");
            player.health -= AttackDamage;

        }
        public void DropItem()
        {
            Item droppedItem = (Item.ListOfItems[random.Next(Item.ListOfItems.Length)]);
            

        }
    }
}
