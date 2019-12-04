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



        public Item(int health, int strength)
        {
            BonusHealth = health;
            BonusStrength = strength;
        }
       
    }
}
