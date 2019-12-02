using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Enemy
    {
        Random random = new Random();

        public string name;
        public int health;
        public int strength;

        public Enemy(string Name)
        {
            name = Name;
            health = random.Next(10,21); //multiplicerat med nivå, exponentiellt på ngt snyggt sätt
            strength = random.Next(1,4);
        }
    }
}
