using System;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Level
    {

        public Level()
        {
            LevelValue = 1;
        }
        public int LevelValue { get; set; }
       
        public void LevelUpEnemy()
        {
            if (LevelValue % 3 == 0)
            {
                LevelValue++;
            }
        }
    }
}

