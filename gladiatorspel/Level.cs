using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Level
    {
     
        public int LevelValue;
        public int Round;


        //======METHOD LEVEL ROUND======//
        public int NextLevel(int round)
        {
            if (round == 3)
            {
                LevelValue++;
                Round = 0;
            }
            return LevelValue;
        }
        /*
            while (true)
            {
                Enemy Enemy = new Enemy(LevelValue);
                Console.WriteLine("Your strenght: {0}", Player.strength);
                Console.WriteLine("Your health: {0}", Player.health);
                Console.WriteLine();
                Console.WriteLine("{0} has strenght: {1}", Enemy.name, Enemy.strength);
                Console.WriteLine("{0} has health: {1}", Enemy.name, Enemy.health);

                while (Enemy.health > 0 && Player.health > 0)
                {
                    Enemy.Attack(Player);
                    Player.Attack(Enemy);

                    if (Enemy.health <= 0)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("You win!");
                        Player.credits += Credits;
                        break;
                    }
                    else if (Player.health <= 0)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Sry bae. Enemy killed you.");
                        break;
                    }

                    Console.WriteLine("Your health: {0}", Player.health);
                    Console.WriteLine();
                    Console.WriteLine("{0} has health: {1}", Enemy.name, Enemy.health);
                }

                Player.health++;
                Round++;

                
            }*/
        
    }
}
