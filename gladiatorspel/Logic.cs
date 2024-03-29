﻿using System;
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
        public String GetName()
        {
            if (names.Count == 0)
            {
                names.AddRange(Enemy.EnemyNames);
            }
            String randomName = names[random.Next(names.Count)];
            names.Remove(randomName);
            return randomName;
        }
        public Item Fight(Gladiator Player, Enemy Opponent)
        {
            if (Player.GetHealth() > 0)
            {
                int dmg = Player.Attack(Opponent);
                Draw.ShowEnemyStats(Opponent, true, dmg);
            }
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
                String textFile = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
                using (StreamWriter writer = new StreamWriter(textFile, true))
                {
                    foreach (Object opponent in DefeatedOpponents)
                    {
                        writer.WriteLine(opponent);
                    }
                    writer.WriteLine(Player.credits + " credits");
                }
            }
            return null;
        }

        public Credit GetCredit()
        {
            return credit;
        }
    }
}