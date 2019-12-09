using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Logic
    {


        public void Menu()
        {
            Console.WriteLine("\nMENU\n");
            Console.WriteLine("1. Play" +
                "\n2. Check inventory" +
                "\n3. Quit");
        }

        public Item[] ListOfItems =
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
    }
}
