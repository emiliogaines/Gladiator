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
        private readonly string[] EnemyNames = { "Gurra", "Kalle", "MioMinMio", "Mao the Red", "SidVicious", "Jack the Shining", "Hannibal" };
        
        


        public Enemy(int level)
        {
            name = EnemyNames[random.Next(EnemyNames.Length)];
            baseHealth = random.Next(10,21);
            baseStrength = random.Next(1,4);

            health = baseHealth * level;
            strength = baseStrength * level;
        }

        public void Attack(Gladiator player)
        {

            Console.WriteLine("{0} attacks!", name);
            int attackDamage = strength;
            Console.WriteLine("{0} dealt {1} damage to you.",name, attackDamage);
            player.health -= attackDamage;

        }
    }
}
