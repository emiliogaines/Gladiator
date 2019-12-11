using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Text;


namespace gladiatorspel
{
    public class Logic
    {
        readonly Credit credit = new Credit();
        readonly Random random = new Random();
        public ArrayList DefeatedOpponents = new ArrayList();
        private List<String> names = new List<String>();

        public Logic()
        {

        }

        public String getName()
        {
            if (names.Count == 0)
            {
                names.AddRange(Enemy.EnemyNames);
            }
            String randomName = names[random.Next(names.Count)];
            names.Remove(randomName);
            return randomName;
        }


        public void DisplayMenu()
        {
            //Console.Clear();
            //Console.WriteLine("\nMENU\n");
            //Console.WriteLine("1. Fight" +
            //   "\n2. Check inventory" +
            //    "\n3. Quit");
        }


        public Item Fight(Gladiator Player, Enemy Opponent)
        {
            // press anything to attack


            //you attack

            if (Player.GetHealth() > 0)
            {
                int dmg = Player.Attack(Opponent);
                Draw.ShowEnemyStats(Opponent, true, dmg);
            }


            //enemy attacks
            if (Opponent.health > 0)
            {
                int enemyDmg = Opponent.Attack(Player);
                Draw.ShowPlayerStats(Player, true, enemyDmg, Opponent);
            }
            else
            {
                credit.BattleCredit(Player, Program.Round);
                DefeatedOpponents.Add(Opponent.name);
                return Opponent.DropItem();
            }

            if (Player.GetHealth() <= 0)
            {
                //File.WriteAllLines(@"C:\\Users\\moa\\Documents\\GitHub\\WriteLines.txt", (IEnumerable<string>)DefeatedOpponents.ToArray());

                using (StreamWriter writer = new StreamWriter("C:\\Users\\moa\\Documents\\GitHub\\GAMESTATS.txt", true))
                {
                    foreach (Object opponent in DefeatedOpponents)
                    {
                        writer.WriteLine(opponent.ToString());
                    }
                    writer.WriteLine(Player.credits);
                }
                // YOU DIED
            }
        }

    }
}