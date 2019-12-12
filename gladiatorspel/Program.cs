using System;

namespace gladiatorspel
{
    class Program
    {

        private static Boolean showingInventory;
        public static int Round = 0;
        static void Main(string[] args)
        {
            String name;
            Draw.initWindowSettings();
            Draw.InitWindow();
            Draw.displayStartup();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("Huh... Please step into the arena " + name, 3);

            Gladiator Player = new Gladiator(name);

            Draw.ShowPlayerStats(Player, false, 0, null);
            Draw.ShowTextPressEnter("< Press Enter to step into the arena >", 5);
            Draw.ShowText("You step into the arena.", 5);


            Logic logic = new Logic();
            Enemy Opponent;
            Item droppedItem = null;

            do
            {
                Round++;
                Opponent = new Enemy(logic.GetName(), Round);
                Draw.ShowEnemyStats(Opponent, false, 0);
                if (Round != 1)
                {
                    Draw.centerText(Opponent.name + " approaches you.", 6);
                    Draw.centerText("", 7);
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
                    droppedItem = logic.Fight(Player, Opponent);
                }
                if (Player.GetHealth() <= 0)
                {
                    break;
                }
                Player.RemoveActivePotion();
                Draw.Clear();
                Draw.InitWindow();
                Draw.ShowRound(Round);
                Draw.ShowPlayerStats(Player, false, 0, null);
                Draw.ShowEnemyStats(Opponent, false, 0);
                Draw.centerText("You defeated " + Opponent.name + "!", 5);
                if (droppedItem != null) Draw.centerText(Opponent.name + " dropped " + droppedItem.Name + " [" + droppedItem.Rarity + "]", 6);
                Draw.centerText("< Press Enter to continue >", 7);
                Draw.ShowTextPressEnter(" ", 8);
                Player.inventory.AddToInventory(droppedItem);
            } while (Player.GetHealth() > 0);

            Draw.Clear();
            Draw.centerText("  _____          __  __ ______    ______      ________ _____  ", Draw.HEIGHT / 2 - 4);
            Draw.centerText(" / ____|   /\\   |  \\/  |  ____|  / __ \\ \\    / /  ____|  __ \\ ", Draw.HEIGHT / 2 - 3);
            Draw.centerText("| |  __   /  \\  | \\  / | |__    | |  | \\ \\  / /| |__  | |__) |", Draw.HEIGHT / 2 - 2);
            Draw.centerText("| | |_ | / /\\ \\ | |\\/| |  __|   | |  | |\\ \\/ / |  __| |  _  / ", Draw.HEIGHT / 2 - 1);
            Draw.centerText("| |__| |/ ____ \\| |  | | |____  | |__| | \\  /  | |____| | \\ \\ ", Draw.HEIGHT / 2);
            Draw.centerText(" \\_____/_/    \\_\\_|  |_|______|  \\____/   \\/   |______|_|  \\_\\", Draw.HEIGHT / 2 + 1);
            Draw.centerText("You survived to Round (" + Round + ") and gathered " + Player.credits + " credits!", Draw.HEIGHT / 2 + 3);
            while (true) { }
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
            while (Console.KeyAvailable) Console.ReadKey(true);
            Boolean deleteMode = false;
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
                else if (showingInventory && (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
                    key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.D5 ||
                    key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.D7 || key.Key == ConsoleKey.D8))
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
                        if (Player.inventory.inventoryList.Count > selected - 1) Player.inventory.inventoryList.RemoveAt(selected - 1);
                    }
                    else
                    {
                        Player.EquipItem(Player.inventory.GetFromInventory(selected - 1));
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
            return str.PadLeft(padLeft - 1, chr).PadRight(length - 2, chr);
        }
    }
}