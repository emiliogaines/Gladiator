using System;

namespace gladiatorspel
{
    class Program
    {

        private static Boolean showingInventory;
        public static int Round = 0;
        static void Main(string[] args)
        {
            Draw.initWindowSettings();



            String name;

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);

            Random random = new Random();
            for(int r = 0; r < 5; r++)
            {
                int randomNumber = random.Next(0, Item.ListOfItems.Length);
                Player.inventory.addToInventory(Item.ListOfItems[randomNumber]);
            }



            Draw.ShowPlayerStats(Player, false, 0, null);
            Draw.ShowTextPressEnter("< Press Enter to step into the arena >", 5);
            Draw.ShowText("You step into the arena.", 5);
           

            Logic logic = new Logic();
            Enemy Opponent;

            do
            {
                Round++;
                Opponent = new Enemy(logic.getName(), Round);
                Draw.ShowEnemyStats(Opponent, false, 0);
                if (Round != 1) { 
                    Draw.centerText(Opponent.name + " approaches you.", 6);
                    Draw.centerText("< Press Enter to begin fight >", 8);
                    Draw.ShowTextPressEnter(" ", 9);
                }
                else
                {
                    Draw.ShowText(Opponent.name + " approaches you.", 6);
                    Draw.ShowText("< Press Enter to begin fight >", 8);
                    Draw.ShowTextPressEnter(" ", 9);
                }
                Draw.Clear();
                Draw.InitWindow();

                Draw.ShowRound(Round);
                while (Opponent.health > 0 && Player.GetHealth() > 0)
                {
                    Draw.ShowPlayerStats(Player, false, 0, null);
                    Draw.ShowEnemyStats(Opponent, false, 0);
                    Draw.FightOptions();
                    handleInput(Player, Opponent);
                    Draw.ClearFightOptions();

                    logic.Fight(Player, Opponent);

                }
                if(Player.GetHealth() <= 0)
                {
                    return;
                }

                Player.RemoveActivePotion();
                Draw.Clear();
                Draw.InitWindow();

                Draw.ShowRound(Round);
                Draw.ShowPlayerStats(Player, false, 0, null);
                Draw.ShowEnemyStats(Opponent, false, 0);
                Draw.centerText("You defeated " + Opponent.name + "!", 5);
                Draw.centerText("< Press Enter to continue >", 6);
                Draw.ShowTextPressEnter(" ", 7);

                
               
            } while (Player.GetHealth() > 0);



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
            Boolean deleteMode = false;
            //while (Console.In.Peek() != -1)Console.In.Read();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.I)
                {
                    if (showingInventory)
                    {
                        Draw.HidePlayerInventory(Player);
                        Draw.ShowEnemyStats(Opponent, false, 0);
                        Draw.FightOptions();
                        deleteMode = false;
                    }
                    else
                    {
                        Draw.ShowPlayerInventory(Player, false);
                    }
                    showingInventory = !showingInventory;

                }
                else if (showingInventory && (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.D7 || key.Key == ConsoleKey.D8))
                {
                    int selected = 0;
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            selected = 1;
                            break;
                        case ConsoleKey.D2:
                            selected = 2;
                            break;
                        case ConsoleKey.D3:
                            selected = 3;
                            break;
                        case ConsoleKey.D4:
                            selected = 4;
                            break;
                        case ConsoleKey.D5:
                            selected = 5;
                            break;
                        case ConsoleKey.D6:
                            selected = 6;
                            break;
                        case ConsoleKey.D7:
                            selected = 7;
                            break;
                        case ConsoleKey.D8:
                            selected = 8;
                            break;
                    }
                    if (deleteMode)
                    {
                        if(Player.inventory.inventoryList.Count > selected - 1)Player.inventory.inventoryList.RemoveAt(selected - 1);
                    }
                    else
                    {
                        Player.EquipItem(Player.inventory.getFromInventory(selected - 1));
                    }
                    Draw.ShowPlayerInventory(Player, deleteMode);
                    Draw.ShowPlayerStats(Player, false, 0, null);
                }
                else if (key.Key == ConsoleKey.D && showingInventory)
                {
                    deleteMode = !deleteMode;
                    Draw.ShowPlayerInventory(Player, deleteMode);
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
