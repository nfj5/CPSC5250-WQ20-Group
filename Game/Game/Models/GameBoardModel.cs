using System;
using Game.Models;
namespace Game.Models
{
    public class GameBoardModel
    {
        public GameBoardModel()
        {
            DefaultModel[,] Gameboard = new DefaultModel[9, 9];
        }
    }
}
