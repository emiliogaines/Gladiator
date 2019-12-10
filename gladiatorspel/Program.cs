using System;

namespace gladiatorspel
{
    class Program
    {

        private static Boolean showingInventory = false;
        private static Boolean fighting = true;
        static void Main(string[] args)
        {
<<<<<<< HEAD
            Boolean showingInventory = false;
=======
            //Ska enemy och gladiator attackera med samma styrka hela tiden på en och samma level?
            //Ska enemy och gladiator ha samma random max min på baseStrenght?
            //Ska hälsa och stryka synas? JA


>>>>>>> 55c429a3b3201b4f6028d36dbcd1e7333856c014

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
            Draw.ShowTextPressEnter("< Press Enter to step into the arena >", 5);
            Draw.ShowText("You step into the arena.", 5);
            Draw.ShowText(Opponent.name + " approaches you.", 6);

            Draw.ShowEnemyStats(Opponent, false);

            Draw.ShowTextPressEnter("< Press Enter to begin fight >", 8);
            Draw.Clear();
            Draw.InitWindow();

<<<<<<< HEAD
            


            //Draw.ShowLevel(level.LevelValue);         MIO FIXA
            Draw.ShowPlayerStats(Player);
            Draw.ShowEnemyStats(Opponent);
=======
>>>>>>> 55c429a3b3201b4f6028d36dbcd1e7333856c014


            /*
              __  __    ___       _        ___   ____       ____   ____    ___   _   _    ____   _____
             |  \/  |  / _ \     / \      |_ _| / ___|     / ___| |  _ \  |_ _| | \ | |  / ___| | ____|
             | |\/| | | | | |   / _ \      | |  \___ \    | |     | |_) |  | |  |  \| | | |  _  |  _|
             | |  | | | |_| |  / ___ \     | |   ___) |   | |___  |  _ <   | |  | |\  | | |_| | | |___
             |_|  |_|  \___/  /_/   \_\   |___| |____/     \____| |_| \_\ |___| |_| \_|  \____| |_____|

             */

        }

        private static void handleInput(Gladiator Player, Enemy Opponent)
        {
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
