﻿using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    class Level
    {
        public Level()
        {
            LevelValue = 1;
            Round = 0;
            Credits = 100;
        }
        public int LevelValue { get; set; }
        public int Round { get; set; }
        public int Credits { get; set; }

        //======METHOD LEVEL ROUND======//
        public void LevelRound(Gladiator Player)
        {
            while (true)
            {
                Enemy Enemy = new Enemy(LevelValue);
                Console.WriteLine("Your strenght: {0}", Player.strength);
                Console.WriteLine("Your health: {0}", Player.health);
                Console.WriteLine();
                Console.WriteLine("{0} has strenght: {1}", Enemy.name, Enemy.strength);
                Console.WriteLine("{0} has health: {1}", Enemy.name, Enemy.health);

                while (true)
                {
                    Enemy.Attack(Player);
                    Player.Attack(Enemy);

                    if (Enemy.baseHealth <= 0)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("You win!");
                        Player.credits += Credits;
                        break;
                    }
                    else if (Player.baseHealth <= 0)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Sry bae. Enemy killed you.");
                        break;
                    }

                    Console.WriteLine("Your health: {0}", Player.health);
                    Console.WriteLine();
                    Console.WriteLine("{0} has health: {1}", Enemy.name, Enemy.health);
                }

                Player.baseHealth++;
                Round++;

                if (Round == 2)
                {
                    LevelValue++;
                    Credits += 100;
                    Round = 0;
                }
            }
        }
    }
}