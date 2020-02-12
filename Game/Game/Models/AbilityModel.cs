using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class AbilityModel
    {
        // Public attributes
        public float SpeedMultiplier { get; set; }
        public float StrengthMultiplier { get; set; }
        public float HitPointModifier { get; set; }
        public float ThiccnessModifier { get; set; }
        public int Cooldown { get; set; }
    }
}
