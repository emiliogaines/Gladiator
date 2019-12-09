using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Item
    {
        public static Item[] ListOfItems =
        {
            new Item("Helm Of Vitality", 15,5, ItemType.HELMET),
            new Item("Chestpiece of Strength",5,15, ItemType.CHEST),
            new Item("Skullcrusher Helmet", 0, 40, ItemType.HELMET),
            new Item("Sword of Power",0,20,ItemType.WEAPON),
            new Item ("Fists of FUry",0,10,ItemType.WEAPON),
            new Potions("Small Health Potion",15,0,ItemType.POTION),
            new Potions("Large Health Potion",35,0,ItemType.POTION),
            new Potions("Small Strength Potion",0,15,ItemType.POTION),
            new Potions("Large Strength Potion",0,35,ItemType.POTION)
        };
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
        public Potions(string n, int temporaryHealthBoost, int temporaryStrengthBoost, ItemType t) :
            base(n, temporaryHealthBoost, temporaryStrengthBoost, t)
        {
            
        }
    }
    

}
public enum ItemType
{
    HELMET , 
    CHEST ,
    WEAPON,
    POTION
}
