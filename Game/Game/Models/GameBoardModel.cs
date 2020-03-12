using System;
using System.Diagnostics;
using Game.Models;
namespace Game.Models
{
    public static class GameBoardModel
    {
       
        public static int Size = 6;
        public static PlayerInfoModel[,] PlayerLocations = new PlayerInfoModel[Size,Size];
        public static ItemModel[,] ItemLocations = new ItemModel[Size, Size];

        
        /// <summary>
        /// Wipe the game board
        /// </summary>
        public static void Wipe()
        {
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
        public static bool Place(PlayerInfoModel player, int x, int y)
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
        public static bool Place(ItemModel item, int x, int y)
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
        public static PlayerInfoModel GetPlayer(int x, int y)
        {
            return PlayerLocations[x, y];
        }

        /// <summary>
        /// Get the ItemModel from the desired position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ItemModel GetItem(int x, int y)
        {
            return ItemLocations[x, y];
        }
        

        /// <summary>
        /// Get the location of a PlayerInfoModel object
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static int[] GetPlayerLocation(PlayerInfoModel player)
        {
            int[] location = new int[2];
            location[0] = Int32.MinValue;
            location[1] = Int32.MinValue;

            for (int x = 0; x < Size; ++x)
            {
                for (int y = 0; y < Size; ++y)
                {
                    // TODO Change to ID
                    if (PlayerLocations[x,y] != null && player.Name == PlayerLocations[x,y].Name)
                    {
                        location[0] = x;
                        location[1] = y;
                    }
                }
            }

            return location;
        }

        /// <summary>
        /// Get the location of a PlayerInfoModel object
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static int[] GetItemLocation(ItemModel item)
        {
            int[] location = new int[2];
            location[0] = Int32.MinValue;
            location[1] = Int32.MinValue;

            for (int x = 0; x < Size; ++x)
            {
                for (int y = 0; y < Size; ++y)
                {
                    if (item.Id == ItemLocations[x, y].Id)
                    {
                        location[0] = x;
                        location[1] = y;
                    }
                }
            }

            return location;
        }

        
    }
}
