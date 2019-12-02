using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Enemy
    {
        Random random = new Random();

        public string name;
        public int baseHealth, health;
        public int baseStrength, strength;

        public Enemy(string Name, int level)
        {
            name = Name;
            baseHealth = random.Next(10,21);
            baseStrength = random.Next(1,4);

            health = baseHealth * level;
            strength = baseStrength * level;
        }



        public void attack(Gladiator player)
        {

            Console.WriteLine("{0} attacks!", name);
            int attackDamage = strength;
            Console.WriteLine("{0} dealt {1} damage to you.",name, attackDamage);
            player.health -= attackDamage;

        }
    }
}
