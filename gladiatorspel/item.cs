using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Item
    {
        public int Health { get; }
        public int Strength { get; }



        public Item(int health, int strength)
        {
            Health = health;
            Strength = strength;
        }
       
    }
}
