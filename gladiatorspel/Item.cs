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
            new Item("Skullcrusher Helmet", 0, 40, ItemType.HELMET),
            new Item("Baseball Cap", 15,5, ItemType.HELMET),
            new Item("Fishing Hat", 5,5, ItemType.HELMET),
            new Item("Flanell Shirt",5,15, ItemType.CHEST),
            new Item("Tube Top",0,10,ItemType.CHEST),
            new Item("Satans Hoodie",25,25,ItemType.CHEST),
            new Item("Sword of Power",0,30,ItemType.WEAPON),
            new Item("Fists of Fury",0,20,ItemType.WEAPON),
            new Item("Kitten Mitten",10,10,ItemType.WEAPON),
            new Item("AK-47",0,60,ItemType.WEAPON),
            new Potions("Small Health Potion",15,0,ItemType.POTION),
            new Potions("Large Health Potion",35,0,ItemType.POTION),
            new Potions("Small Strength Potion",0,15,ItemType.POTION),
            new Potions("Large Strength Potion",0,35,ItemType.POTION)
        };
        public int BonusHealth { get; set; }
        public int BonusStrength { get; set; }
        public ItemType Type { get; }
        public Double DropChance { get; }

        public string Name { get; set; }

        public Item(string name, int health, int strength, ItemType itemType, Double dropChance)
        {
            Name = name;
            BonusHealth = health;
            BonusStrength = strength;
            Type = itemType;
            DropChance = dropChance;
        }

        public override String ToString()
        {
            return Name + " [" + BonusHealth + "," + BonusStrength + "]";
        }

    }
    public class Potions : Item
    {
        public Potions(string n, int temporaryHealthBoost, int temporaryStrengthBoost, ItemType t, Double d) :
            base(n, temporaryHealthBoost, temporaryStrengthBoost, t, d)
        {

        }
    }





}
public enum ItemType
{
    HELMET,
    CHEST,
    WEAPON,
    POTION
}
