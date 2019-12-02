using System;
namespace gladiatorspel
{
    public class Draw
    {
        public static void initWindow()
        {
            const String Title = "[ GLADIATOR ]";
            int WIDTH = Console.WindowWidth;
            int HEIGHT = Console.WindowHeight;

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
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
        }

        public static void updateText(String text, int line)
        {
            if (line < 1) return;
            const int STARTX = 2;
            const int STARTY = 0;
            Console.SetCursorPosition(STARTX, STARTY + line);
            Console.Write(text.PadRight(Console.WindowWidth - STARTX));
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
