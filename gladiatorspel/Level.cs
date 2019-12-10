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
       
        public void NextLevel()
        {
            if (LevelValue % 3 == 0)
            {
                LevelValue++;
            }
        }

        public void BoostEnemy()
        {

        }
    }
}

