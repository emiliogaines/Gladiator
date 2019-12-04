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
            Player.inventory.addToInventory(Item HelmOfVitality = new Item("Helm of Vitality", 15, 5));
            Player.inventory.addToInventory(Item ChestpieceOfStrength = new Item("Chestpiece of Strength", 5, 15));
            Player.inventory.addToInventory(Item SkullcrusherHelmet = new Item("Skullchrusher Helmet", 0, 40));
            Player.inventory.addToInventory(new Item("Skullchrusher Helmet", 0, 40));


            Draw.ShowPlayerStats(Player);
            Player.checkInventory();

            while (true) { }

        }
    }
}
