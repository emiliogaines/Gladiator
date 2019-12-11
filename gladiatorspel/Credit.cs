using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Credit
    {
        Random random = new Random();
        public int Credits { get; set; }
        public int Money;
        public Credit()
        {
            Credits = 100;
            Money = random.Next(50, 151);
        }
        public void BattleCredit(Gladiator gladiator, int level)
        {
            gladiator.credits += Credits * level;
        }
        public void DeadEnemyMoneyDrop(Gladiator gladiator)
        {
            gladiator.credits += Money;
        }
    }
}
