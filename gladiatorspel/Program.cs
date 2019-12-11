using System;

namespace gladiatorspel
{
    class Program
    {

        private static Boolean showingInventory;
        private static Boolean fighting = true;
        public static int Round = 1;
        static void Main(string[] args)
        {
            Draw.initWindowSettings();
            //Ska enemy och gladiator attackera med samma styrka hela tiden på en och samma level?
            //Ska enemy och gladiator ha samma random max min på baseStrenght?
            //Ska hälsa och stryka synas? JA



            String name;

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);
            Enemy Opponent = new Enemy(Round);

            Random random = new Random();
            for(int r = 0; r < 5; r++)
            {
                int randomNumber = random.Next(0, Item.ListOfItems.Length);
                Player.inventory.addToInventory(Item.ListOfItems[randomNumber]);
            }



            Draw.ShowPlayerStats(Player, false, 0, null);
            Draw.ShowTextPressEnter("< Press Enter to step into the arena >", 5);
            Draw.ShowText("You step into the arena.", 5);
            Draw.ShowText(Opponent.name + " approaches you.", 6);

            Draw.ShowEnemyStats(Opponent, false, 0);

            Draw.ShowTextPressEnter("< Press Enter to begin fight >", 8);
            Draw.Clear();
            Draw.InitWindow();

            Draw.ShowRound(Round);

            Logic logic = new Logic();

            while(Player.GetHealth() > 0)
            {
                while (Opponent.health > 0){
                    Draw.ShowPlayerStats(Player, false, 0, null);
                    Draw.ShowEnemyStats(Opponent, false, 0);
                    Draw.FightOptions();
                    handleInput(Player, Opponent);
                    Draw.ClearFightOptions();
                    
                    logic.Fight(Player, Opponent);

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

                Opponent = new Enemy(Round);
                Round++;

                Draw.centerText(Opponent.name + " approaches you.", 5);
                Draw.ShowEnemyStats(Opponent, false, 0);
                Draw.centerText("< Press Enter to begin fight >", 6);
                Draw.ShowTextPressEnter(" ", 7);

                Draw.Clear();
                Draw.InitWindow();
                Draw.ShowRound(Round);
            }



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
                    }
                    else
                    {
                        Draw.ShowPlayerInventory(Player);
                    }
                    showingInventory = !showingInventory;
                }
                else if (showingInventory && (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.D7 || key.Key == ConsoleKey.D8))
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Player.EquipItem(Player.inventory.getFromInventory(0));
                            break;
                        case ConsoleKey.D2:
                            Player.EquipItem(Player.inventory.getFromInventory(1));
                            break;
                        case ConsoleKey.D3:
                            Player.EquipItem(Player.inventory.getFromInventory(2));
                            break;
                        case ConsoleKey.D4:
                            Player.EquipItem(Player.inventory.getFromInventory(3));
                            break;
                        case ConsoleKey.D5:
                            Player.EquipItem(Player.inventory.getFromInventory(4));
                            break;
                        case ConsoleKey.D6:
                            Player.EquipItem(Player.inventory.getFromInventory(5));
                            break;
                        case ConsoleKey.D7:
                            Player.EquipItem(Player.inventory.getFromInventory(6));
                            break;
                        case ConsoleKey.D8:
                            Player.EquipItem(Player.inventory.getFromInventory(7));
                            break;
                    }
                    Draw.ShowPlayerInventory(Player);
                    Draw.ShowPlayerStats(Player, false, 0, null);
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
