using System;
using Game.Models;
namespace Game.Models
{
    public class GameBoardModel
    {
        private DefaultModel[,] Gameboard;
        private int Size = 10;

        public GameBoardModel()
        {
            Gameboard = new DefaultModel[Size, Size];

            // Initialize the Gameboard to null
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    Gameboard[i, j] = null;
                }
            }
        }

        /// <summary>
        /// Place a DefaultModel at the specified location, if it is empty.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool place(DefaultModel model, int x, int y)
        {
            if (Gameboard[x,y] != null)
            {
                return false;
            }

            Gameboard[x, y] = model;

            return true;
        }

        /// <summary>
        /// Get the DefaultModel from the desired position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public DefaultModel get(int x, int y)
        {
            return Gameboard[x, y];
        }
    }
}
