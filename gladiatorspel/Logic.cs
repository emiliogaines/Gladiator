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
            new Item("Helm Of Vitality", 15,5),
            new Item("Chestpiece of Strength",5,15),
            new Item("Skullcrusher Helmet", 0, 40)};
    }
}
