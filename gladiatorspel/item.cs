using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Item
    {
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
