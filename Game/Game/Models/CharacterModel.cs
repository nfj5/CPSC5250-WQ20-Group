using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    // CharacterModel extends PersonModel (and is literally just uses that)
    public class CharacterModel: PersonModel
    {
        public void Update(CharacterModel newData)
        {
            if(newData == null)
            {
                return;
            }

            BaseSpeed = newData.BaseSpeed;
            BaseStrength = newData.BaseStrength;
            BaseHitPoints = newData.BaseHitPoints;
            BaseThiccness = newData.BaseThiccness;
        }

    }
}
