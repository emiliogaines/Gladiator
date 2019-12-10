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

            while (Opponent.health > 0 && Player.health > 0)
            {
                //you attack
                Player.Attack(Opponent);
                //enemy attacks
                Opponent.Attack(Player);
            }
            if (Opponent.health <= 0)
            {
                //YOU KILLED [ENEMY]
                //Add to list / rapport över besegrade motståndare

                credit.BattleCredit(Player, Program.level);
                DefeatedOpponents.Add(Opponent.name);
            }
            if (Player.health <= 0)
            {
                // YOU DIED
            }
        }

    }
}
