using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Item
    {
        public int BonusHealth { get; set; }
        public int BonusStrength { get; set; }

        public string Name { get; set; }

        public Item(string name, int health, int strength)
        {
            Name = name;
            BonusHealth = health;
            BonusStrength = strength;
        }


    }
    public class Potions : Item
    {
        public Potions(string n, int temporaryHealthBoost, int temporaryStrengthBoost) : base(n, temporaryHealthBoost, temporaryStrengthBoost)
        {
            
        }
    }

}
