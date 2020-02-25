using System;
using Game.Models;
namespace Game.Models
{
    public class GameBoardModel
    {
        private DefaultModel[,] Gameboard;
        private PlayerInfoModel[,] PlayerLocations;
        private ItemModel[,] ItemLocations;
        private int Size = 10;

        public GameBoardModel()
        {
            PlayerLocations = new PlayerInfoModel[Size, Size];
            ItemLocations = new ItemModel[Size, Size];

            // Initialize the Gameboard to null
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    PlayerLocations[i, j] = null;
                    ItemLocations[i, j] = null;
                }
            }
        }

        /// <summary>
        /// Place a PlayerInfoModel at the specified location, if there is not another player there.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool place(PlayerInfoModel player, int x, int y)
        {
            if (PlayerLocations[x,y] != null)
            {
                return false;
            }

            PlayerLocations[x, y] = player;

            return true;
        }

        /// <summary>
        /// Place an ItemModel at the specified location, if there is not another Item there.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool place(ItemModel item, int x, int y)
        {
            if (ItemLocations[x, y] != null)
            {
                return false;
            }

            ItemLocations[x, y] = item;

            return true;
        }

        /// <summary>
        /// Get the PlayerInfoModel from the desired position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PlayerInfoModel getPlayer(int x, int y)
        {
            return PlayerLocations[x, y];
        }

        /// <summary>
        /// Get the ItemModel from the desired position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public ItemModel getItem(int x, int y)
        {
            return ItemLocations[x, y];
        }
    }
}
