using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Credit
    {
        public int Credits { get; set; }

        public Credit()
        {
            Credits = 100;
        } 

        public void BattleCredit(int gladiatorHealth, int enemyHealth)
        {
            if (gladiatorHealth > enemyHealth)
            {

            }
        }
    }
}
