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
        public ItemType Type { get; }

        public string Name { get; set; }

        public Item(string name, int health, int strength, ItemType itemType)
        {
            Name = name;
            BonusHealth = health;
            BonusStrength = strength;
            Type = itemType; 
        }


    }
    public class Potions : Item
    {
        public Potions(string n, int temporaryHealthBoost, int temporaryStrengthBoost, ItemType t) : base(n, temporaryHealthBoost, temporaryStrengthBoost, t)
        {
            
        }
    }
    

}
public enum ItemType
{
    HELMET , 
    CHEST ,
    WEAPON
}
