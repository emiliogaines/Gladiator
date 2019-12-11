using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace gladiatorspel
{
    public class Logic
    {
        readonly Credit credit = new Credit();
        public ArrayList DefeatedOpponents = new ArrayList(); 


        public void DisplayMenu()
        {
            //Console.Clear();
            //Console.WriteLine("\nMENU\n");
            //Console.WriteLine("1. Fight" +
            //   "\n2. Check inventory" +
            //    "\n3. Quit");
        }


        public void Fight(Gladiator Player, Enemy Opponent)
        {
            // press anything to attack

            if (Opponent.health > 0 && Player.health > 0)
            {
                //you attack
                int dmg = Player.Attack(Opponent);
                Draw.GladiatorAttack(dmg);
                Draw.ShowEnemyStats(Opponent, true);
                //enemy attacks
                int enemyDmg = Opponent.Attack(Player);
                Draw.EnemyAttack(enemyDmg);
                Draw.ShowPlayerStats(Player);
            }
            if (Opponent.health <= 0)
            {
                //YOU KILLED [ENEMY]
                //Add to list / rapport över besegrade motståndare

                credit.BattleCredit(Player, Program.Round);
                DefeatedOpponents.Add(Opponent.name);
            }
            if (Player.health <= 0)
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\moa\\Documents", true))
                {
                    foreach(Object opponent in DefeatedOpponents)
                    {
                        writer.WriteLine(opponent.ToString());
                    }
                }
                // YOU DIED
            }
        }

    }
}
