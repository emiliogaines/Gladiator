using System;

namespace gladiatorspel
{
    class Program
    {
        public static int level = 1;

        static void Main(string[] args)
        {
            Boolean showingInventory = false;

            String name;

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);
            Enemy Opponent = new Enemy(level);

            Random random = new Random();
            for(int r = 0; r < 5; r++)
            {
                int randomNumber = random.Next(0, Item.ListOfItems.Length);
                Player.inventory.addToInventory(Item.ListOfItems[randomNumber]);
            }



            Draw.ShowPlayerStats(Player);
            Draw.ShowEnemyStats(Opponent);
            Draw.ShowTextPressEnter("< Press Enter to step into the arena >", 5);
            Draw.ShowText("You step into the arena.", 5);
            Draw.ShowText(Opponent.name + " approaches you.", 6);

            Draw.ShowTextPressEnter("< Press Enter to begin fight >", 8);
            Draw.Clear();
            Draw.InitWindow();

            


            //Draw.ShowLevel(level.LevelValue);         MIO FIXA
            Draw.ShowPlayerStats(Player);
            Draw.ShowEnemyStats(Opponent);

            Opponent.DropItem();

            /*
              __  __    ___       _        ___   ____       ____   ____    ___   _   _    ____   _____
             |  \/  |  / _ \     / \      |_ _| / ___|     / ___| |  _ \  |_ _| | \ | |  / ___| | ____|
             | |\/| | | | | |   / _ \      | |  \___ \    | |     | |_) |  | |  |  \| | | |  _  |  _|
             | |  | | | |_| |  / ___ \     | |   ___) |   | |___  |  _ <   | |  | |\  | | |_| | | |___
             |_|  |_|  \___/  /_/   \_\   |___| |____/     \____| |_| \_\ |___| |_| \_|  \____| |_____|

             */

            while (true)
            {

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.I)
                {
                    if (showingInventory) {
                        Draw.HidePlayerInventory(Player);
                        Draw.ShowEnemyStats(Opponent);
                    }
                    else
                    {
                        Draw.ShowPlayerInventory(Player);
                    }
                    showingInventory = !showingInventory;
                }
                else if (key.Key == ConsoleKey.Enter) break;
            }

        }
    }
}

namespace System
{
    public static class StringExtensions
    {
        public static string PadBoth(this string str, int length, char chr)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft, chr).PadRight(length, chr);
        }
    }
}
