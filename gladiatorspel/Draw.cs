using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace gladiatorspel
{
    public class Draw
    {
        const String Title = "[ GLADIATOR ]";
        private static int WIDTH;
        private static int HEIGHT;

        private static List<int> playerActions = new List<int> ();
        private static List<int> enemyActions = new List<int>();



        public static void InitWindow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); 
            WIDTH = Console.WindowWidth;
            HEIGHT = Console.WindowHeight;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Console.SetBufferSize(WIDTH + 1, HEIGHT + 1);
                Console.SetWindowSize(WIDTH + 1, HEIGHT + 1);
            }
            

            String topLeftCorner = "╔";
            String topRightCorner = "╗";
            String bottomRightCorner = "╝";
            String bottomLeftCorner = "╚";
            String standingEdge = "║";
            String lyingEdge = "═";

            for(int i = 0; i < WIDTH; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(lyingEdge);
                Console.SetCursorPosition(i, HEIGHT);
                Console.Write(lyingEdge);
            }
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(standingEdge);
                Console.SetCursorPosition(WIDTH, i);
                Console.Write(standingEdge);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(topLeftCorner);
            Console.SetCursorPosition(WIDTH, 0);
            Console.Write(topRightCorner);
            Console.SetCursorPosition(0, HEIGHT);
            Console.Write(bottomLeftCorner);
            Console.SetCursorPosition(WIDTH, HEIGHT);
            Console.Write(bottomRightCorner);

            int TitlePos = (WIDTH / 2) - (Title.Length / 2);
            Console.SetCursorPosition(TitlePos, 0);
            Console.Write(Title);
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        private static void prepCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        private static void finishedCursor()
        {
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void ShowText(String text, int line)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadRight(WIDTH - padding));
            Console.SetCursorPosition(WIDTH, line);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void ShowText(String text, int line, int paddingFromEnd)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadLeft(WIDTH - padding - 2));
            Console.SetCursorPosition(WIDTH, line);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static String ShowTextInput(String text, int line)
        {
            ShowText(text, line);
            String input = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input += key.KeyChar;
                ShowText(text + input, line);
            }
            return input;
        }
        
        public static void ShowTextPressEnter(String text, int line)
        {
            ShowText(text, line);
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
            }
        }

        public static void ShowPlayerStats(Gladiator gladiator)
        {
            prepCursor(2, HEIGHT - 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(gladiator.name + " [HP: " + gladiator.GetHealth() + " Attack: " + gladiator.GetStrength() + "]");
            Console.ForegroundColor = ConsoleColor.White;
            finishedCursor();
        }

        public static void ShowEnemyStats(Enemy enemy, Boolean loading)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            String enemyText = enemy.name + " [HP: " + enemy.health + " Attack: " + enemy.strength + "]";
            prepCursor(WIDTH - 2 - enemyText.Length, HEIGHT - 2);
            Console.Write(enemyText);
            Console.ForegroundColor = ConsoleColor.White;

            if (loading)
            {
                Char[] indicators = { '/', '-', '\\', '|', '/', '-', '\\' };
                foreach(Char indicator in indicators)
                {
                    prepCursor(WIDTH - 7 - enemyText.Length, HEIGHT - 2);
                    Console.Write("[" + indicator + "] ");
                    finishedCursor();
                    System.Threading.Thread.Sleep(250);
                }
                prepCursor(WIDTH - 7 - enemyText.Length, HEIGHT - 2);
                Console.Write("    ");
            }

            finishedCursor();
        }

        public static void ShowPlayerInventory(Gladiator player)
        {
            int MaxWidth = 0;
            int MaxWidthEquip = 0;
            int Length = 8;
            String[] equippedPositions = { "HELMET", "BODY", "WEAPON" };
            Item[] equippedItem = { player.EquippedHelmet, player.EquippedChest, player.EquippedWeapon};
            foreach (Item item in Item.ListOfItems)
            {
                foreach(String pos in equippedPositions)
                {
                    if (pos.Length > MaxWidthEquip) MaxWidthEquip = pos.Length;
                }
                if (item.Name.Length + MaxWidthEquip > MaxWidth) {
                    MaxWidth = item.ToString().Length + MaxWidthEquip;
                }
            }
            int MaxWidthFixed = MaxWidth + 8;
            String inventoryTitle = "[ INVENTORY ]";
            String equippedTitle = "[ EQUIPPED  ]";
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 6 - Length);
            Console.Write("╔" + equippedTitle.PadBoth(MaxWidthFixed - 2, '═') + "╣");
            for (int i = 0; i < 3; i++)
            {
                String itemName;
                if(equippedItem[i] != null)
                {
                    itemName = equippedItem[i].ToString();
                }
                else
                {
                    itemName = "";
                }
                String drawString = "║ " + equippedPositions[i] + ": " + itemName.PadLeft(MaxWidth - equippedPositions[i].Length + 2);
                Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 5 - Length + i);
                Console.Write(drawString);
            }
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 2 - Length);
            Console.Write("╠" + inventoryTitle.PadBoth(MaxWidthFixed - 2, '═') + "╣");
            for (int i = 0; i < 8; i++)
            {
                String itemName = "";
                if (player.inventory.inventoryList.Count >= i + 1)
                {
                    itemName = (player.inventory.inventoryList[i] as Item).ToString();
                }
                String drawString = "║ " + string.Format("{0:D2}", i + 1) + ") " + itemName.PadLeft(MaxWidth);
                Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 1 - Length + i);
                Console.Write(drawString);
                
            }
            
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT);
            Console.Write("╩");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void HidePlayerInventory(Gladiator player)
        {
            int Length = 15;
            int MaxWidth = 0;
            int MaxWidthEquip = 0;
            String[] equippedPositions = { "HELMET", "BODY", "WEAPON" };
            foreach (Item item in Item.ListOfItems)
            {
                foreach (String pos in equippedPositions)
                {
                    if (pos.Length > MaxWidthEquip) MaxWidthEquip = pos.Length;
                }
                if (item.ToString().Length + MaxWidthEquip > MaxWidth)
                {
                    MaxWidth = item.ToString().Length + MaxWidthEquip;
                }
            }
            int MaxWidthFixed = MaxWidth + 8;
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 2 - i);
                for(int n = WIDTH - MaxWidthFixed; n < WIDTH - 1; n++)
                {
                    Console.Write(" ");
                }

            }
            Console.SetCursorPosition(WIDTH - MaxWidthFixed + 6, HEIGHT);
            Console.Write("═");
            Console.SetCursorPosition(WIDTH, HEIGHT - Length + 1);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT - Length + 5);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);

        }

        public static void ShowRound(int round)
        {
            String levelText = "[ ROUND " + round + " ]";
            Draw.ShowText(levelText.PadBoth(WIDTH - 2, ' '), 1);
        }

        public static void Clear()
        {
            for(int i = 0; i < HEIGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ".PadRight(WIDTH));
            }
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void FightOptions()
        {
            Draw.ShowText("< Press Enter to attack >".PadBoth(WIDTH - 2, ' '), 6);
        }

        public static void ClearFightOptions()
        {
            Draw.ShowText("".PadBoth(WIDTH - 2, ' '), 6);
        }

        public static void EnemyAttacked(int dmg)
        {
            playerActions.Add(-dmg);
            enemyActions.Add(dmg);
        }

        public static void GladiatorAttacked(int dmg)
        {
            playerActions.Add(dmg);
            enemyActions.Add(-dmg);
        }
    }
}
