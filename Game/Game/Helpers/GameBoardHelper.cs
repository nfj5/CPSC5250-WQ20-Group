﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    class GameBoardHelper
    {
        // Keep track of the round
        public static int Round = 1;

        // Keetp track of the currently selected Character
        public static string SelectedCharacter = null;

        /// <summary>
        /// Calculate the distance between 2 positions on the gameboard.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static int Distance(int x1, int y1, int x2, int y2)
        {
             return ((int) Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
        }
    }
}
