using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    class GameBoardHelper
    {
        public static int Distance(int x1, int y1, int x2, int y2)
        {
             return ((int) Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
        }
    }
}
