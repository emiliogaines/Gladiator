using System;

namespace gladiatorspel
{
    class Program
    {
        static void Main(string[] args)
        {
            String name;

            Enemy level1 = new Enemy(1);

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);
            Draw.ShowPlayerStats(Player);
            Player.CheckInventory();
            level1.Attack(Player);
            while (true) 
            {
            }


        }
    }
}
