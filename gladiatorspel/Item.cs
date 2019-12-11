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
            new Item("Skullcrusher Helmet", 0, 50, ItemType.HELMET,0.01),
            new Item("Baseball Cap", 15,5, ItemType.HELMET,0.20),
            new Item("Fishing Hat", 5,5, ItemType.HELMET,0.75),
            new Item("Flanell Shirt",5,15, ItemType.CHEST,0.30),
            new Item("Tube Top",0,10,ItemType.CHEST,.40),
            new Item("Satans Hoodie",35,35,ItemType.CHEST,0.01),
            new Item("Sword of Power",0,30,ItemType.WEAPON,0.25),
            new Item("Fists of Fury",0,20,ItemType.WEAPON,0.35),
            new Item("Kitten Mitten",10,10,ItemType.WEAPON,0.40),
            new Item("AK-47",0,60,ItemType.WEAPON,0.01),
            new Potions("Small Health Potion",15,0,ItemType.POTION,0.20),
            new Potions("Large Health Potion",35,0,ItemType.POTION,0.15),
            new Potions("Small Strength Potion",0,15,ItemType.POTION,0.35),
            new Potions("Large Strength Potion",0,35,ItemType.POTION,0.30)
        };
        public int BonusHealth { get; set; }
        public int BonusStrength { get; set; }
        public ItemType Type { get; }
        public Double DropChance { get; }

        public string Name { get; set; }

        public static Item getRandomItem()
        {
            Random random = new Random();
            Double randomValue;
            Item randomItem;
            do
            {
                randomValue = random.NextDouble();
                randomItem = ListOfItems[random.Next(ListOfItems.Length)];
            } while (randomValue > randomItem.DropChance);
            return randomItem;
        }

        public Item(string name, int health, int strength, ItemType itemType, Double dropChance)
        {
            Name = name;
            BonusHealth = health;
            BonusStrength = strength;
            Type = itemType;
            DropChance = Math.Clamp(dropChance, 0, 1);
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
