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

            Draw.InitWindow();
            Draw.ShowText("Greetings Gladiator!", 1);
            name = Draw.ShowTextInput("What is your name?: ", 2);
            Draw.ShowText("That is a shit name. Please step into the arena " + name, 3);
            Gladiator Player = new Gladiator(name);
<<<<<<< HEAD
            //Draw.ShowPlayerStats(Player);
            //Player.CheckInventory();

            int level = 1;
            int round = 0;
            int credit = 100;
            bool play = true;

            while (play) 
=======
            Player.inventory.inventoryList.Add(new Item("Hateful speach", 0, 100));
            Player.inventory.inventoryList.Add(new Item("Ugly people", 99, 100));
            Draw.ShowPlayerStats(Player);
            Draw.ShowPlayerInventory(Player);
            //Player.CheckInventory();
            //level1.Attack(Player);
            while (true) 
>>>>>>> c3b6a3b7a005563bce6574c3b114faff14189480
            {
                Enemy enemy = new Enemy(level);

                enemy.Attack(Player);
                Player.Attack(enemy);


                if (enemy.health <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("You win!");
                    Player.credits += credit;
                    break;
                }
                else if (Player.health <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Sry bae. Enemy killed you.");
                    break;
                }

                Player.health++;
                round++;
                if (round == 3)
                {
                    level++;
                    credit += 100;
                    round = 0;
                }
                
            }


        }
    }
}
