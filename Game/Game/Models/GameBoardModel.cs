using System;
using System.Collections.Generic;
using System.Diagnostics;
using Game.Models;
using Game.Models.Enum;
using Game.ViewModels;

namespace Game.Models
{
    public static class GameBoardModel
    {
       
        public static int Size = 6;
        public static PlayerInfoModel[,] PlayerLocations = new PlayerInfoModel[Size,Size];
        public static ItemModel[,] ItemLocations = new ItemModel[Size, Size];

        public static List<MapObject> Locations = new List<MapObject>();

        public static void Wipe()
        {
            // Wipe the MapObjects
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    Locations.Add(new MapObject(i, j, MapObjectEnum.Blank));
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
            if (PlayerLocations[y,x] != null)
            {
                return false;
            }

            PlayerLocations[y, x] = player;

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
            MapObject location = Locations.Find(a => (a.x == x && a.y == y));

            if (location.MapObjectType != MapObjectEnum.Blank)
            {
                return false;
            }

            // MapObject stuff
            location.MapObjectType = MapObjectEnum.Item;
            location.ImageURI = item.ImageURI;
            location.Id = item.Id;

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
            // Rewrite with MapObject
            PlayerInfoModel player = BattleEngineViewModel.Instance.Engine.CharacterList.Find(a => a.Id == Locations.Find(b => (b.x == x && b.y == y)).Id);
            return player;
        }

        public static bool isPlayer(int x, int y)
        {
            if(PlayerLocations[y, x] != null)
            {
                PlayerInfoModel player = PlayerLocations[y, x];
                if(player.PersonType == PersonTypeEnum.Character)
                    return true;
            }
            return false;

        }

        

        /// <summary>
        /// Get the ItemModel from the desired position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ItemModel GetItem(int x, int y)
        {
            return ItemLocations[y, x];
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
                    if (item.Id == ItemLocations[y, x].Id || item.Id == Locations.Find(a => (a.x == x && a.y == y)).Id)
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
