using System;
using System.Collections.Generic;
using System.Text;
using Game.Models.Enum;

namespace Game.Models
{
    public class MapObject
    {
        public int x, y;
        public MapObjectEnum MapObjectType;
        public bool Selected = false;
        public string ImageURI = "blank_space.png";
        public string Id;

        public MapObject(int x, int y, MapObjectEnum MapObjectType)
        {
            this.x = x;
            this.y = y;
            this.MapObjectType = MapObjectType;
        }
    }
}
