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


        public void Fight(Gladiator gladiator, Enemy enemy)
        {
            while (gladiator.health > 0 && enemy.health > 0)
            {
                gladiator.Attack(enemy);
                enemy.Attack(gladiator);
            }
            if (enemy.health <= 0)
            {
                //YOU KILLED [ENEMY]
                //Add to list / rapport över besegrade motståndare

                credit.BattleCredit(gladiator, Program.level);
                DefeatedOpponents.Add(enemy.name);
            }
            if (gladiator.health <= 0)
            {
                // YOU DIED
            }
        }

    }
}
