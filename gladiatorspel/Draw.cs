using System;
using System.Runtime.InteropServices;
namespace gladiatorspel
{
    public class Draw
    {
        public static void InitWindow()
        {
            const String Title = "[ GLADIATOR ]";
            int WIDTH = Console.WindowWidth;
            int HEIGHT = Console.WindowHeight;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Console.SetWindowSize(WIDTH, HEIGHT);
                Console.SetBufferSize(WIDTH, HEIGHT);
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
                Console.SetCursorPosition(i, HEIGHT - 1);
                Console.Write(lyingEdge);
            }
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(standingEdge);
                Console.SetCursorPosition(WIDTH - 1, i);
                Console.Write(standingEdge);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(topLeftCorner);
            Console.SetCursorPosition(WIDTH - 1, 0);
            Console.Write(topRightCorner);
            Console.SetCursorPosition(0, HEIGHT - 1);
            Console.Write(bottomLeftCorner);
            Console.SetCursorPosition(WIDTH - 1, HEIGHT - 1);
            Console.Write(bottomRightCorner);

            int TitlePos = (WIDTH / 2) - (Title.Length / 2);
            Console.SetCursorPosition(TitlePos, 0);
            Console.Write(Title);
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
        }

        public static void ShowText(String text, int line)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadRight(Console.WindowWidth - padding));
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
        }

        public static String ShowTextInput(String text, int line)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadRight(Console.WindowWidth - padding));
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
            String input = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input += (key.KeyChar);
                Console.SetCursorPosition(padding + text.Length, line);
                Console.Write(input);
            }
            return input;
        }
    }
}
