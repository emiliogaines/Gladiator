using System;
using System.Collections;
using System.Collections.Generic;
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

          
                //you attack

            if(Player.health > 0)
            {
                    int dmg = Player.Attack(Opponent);
                    Draw.ShowEnemyStats(Opponent, true, dmg);
            }
                
                
                //enemy attacks
            if(Opponent.health > 0)
            {
                    int enemyDmg = Opponent.Attack(Player);
                    Draw.ShowPlayerStats(Player, true, enemyDmg, Opponent);
            }
            else
            {
                credit.BattleCredit(Player, Program.Round);
                DefeatedOpponents.Add(Opponent.name);
            }

            if (Player.health <= 0)
            {
                // YOU DIED
            }
        }

    }
}
