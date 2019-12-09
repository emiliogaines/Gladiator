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
            Credits = 100;
        }
        public int LevelValue { get; set; }
        public int Credits { get; set; }


        //======METHOD LEVEL ROUND======//
        public void NextLevel()
        {
            if (LevelValue % 3 == 0)
            {
                LevelValue++;
                Credits += 100;
            }
        }
    }
}

