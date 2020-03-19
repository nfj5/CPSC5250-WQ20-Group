using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models.Enum
{
    /// <summary>
    /// Valid object types that can be placed on the GameBoard
    /// </summary>
    public enum MapObjectEnum
    {
        // Nothing is located here
        Blank = 0,

        // There is a Character located on this space
        Character = 10,

        // There is a Monster located on this space
        Monster = 20,

        // There is an Item located on this space
        Item = 30
    }
}
