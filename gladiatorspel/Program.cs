using System;

namespace gladiatorspel
{
    class Program
    {
        static void Main(string[] args)
        {

            /*string Name = Console.ReadLine();

            Gladiator Player = new Gladiator(Name);*/
            String name;

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);

            while (true) { }

        }
    }
}
