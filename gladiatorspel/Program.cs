using System;

namespace gladiatorspel
{
    class Program
    {
        static void Main(string[] args)
        {
            String name;

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);

            while (true) { }

        }
    }
}
