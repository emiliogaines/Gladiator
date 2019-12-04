using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Item
    {
        public string[] ListOfItems = { "Helm of Vitality", "Chestpiece of Strength", "Skullcrusher Helmet" };
        public int BonusHealth { get; }
        public int BonusStrength { get; }

        public string Name { get; }

        public Item(string name, int health, int strength)
        {
            Name = name;
            BonusHealth = health;
            BonusStrength = strength;
        }
       
    }
}
