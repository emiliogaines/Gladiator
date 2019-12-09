using System;

namespace gladiatorspel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ska enemy och gladiator attackera med samma styrka hela tiden på en och samma level? 
            //Ska enemy och gladiator ha samma random max min på baseStrenght?
            //Ska hälsa och stryka synas? JA


            String name;

            Level levelNr = new Level();

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);

            levelNr.LevelRound(Player);
            //Draw.ShowPlayerStats(Player);
            //Player.CheckInventory();

            Player.inventory.inventoryList.Add(new Item("Hateful speach", 0, 100));
            Player.inventory.inventoryList.Add(new Item("Ugly people", 99, 100));
            Draw.ShowPlayerStats(Player);
            Draw.ShowPlayerInventory(Player);
            //Player.CheckInventory();
            //level1.Attack(Player);
            


        }
    }
}
