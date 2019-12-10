using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Logic
    {
        readonly Credit credit = new Credit();

        public void DisplayMenu()
        {
            //Console.Clear();
            //Console.WriteLine("\nMENU\n");
            //Console.WriteLine("1. Fight" +
            //   "\n2. Check inventory" +
            //    "\n3. Quit");
        }

        public void MenuChoice()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey();

            switch (keyInfo)
            {
                case 1:
                    break;
                default:
                    break;
            }
        }

        public void Fight(Gladiator gladiator, Enemy enemy, Level level)
        {
            while (gladiator.health > 0 && enemy.health > 0)
            {
                gladiator.Attack(enemy);
                enemy.Attack(gladiator);
            }
            if (gladiator.health > enemy.health)
            {
                //Gladiator victory
                //Add to list / rapport över besegrade motståndare

                credit.BattleCredit(gladiator, level.LevelValue);       //?
                gladiator.credits = credit.Credits * level.LevelValue;  //Hur är bäst att skriva?
            }
            //Enemy victory
        }

    }
}
