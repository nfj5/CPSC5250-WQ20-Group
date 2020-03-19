namespace Game.Models
{
    /// <summary>
    /// List of Abilities to show for Characters
    /// </summary>
    public enum AbilityEnum
    {
        // Values set spaced out to allow for additional Superstar abilities.

        // Not specified
        Unknown = 0,

        // Speed ability grants Characters extra speed
        SpeedAbility = 1,

        // Strength ability grants Characters extra Attack
        StrengthAbility = 10,

        // Thiccness ability grants Characters extra Defense
        ThiccnessAbility = 20,

        // Stamina ability grants Characters extra HitPoints
        StaminaAbility = 30
    }

    public static class AbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case AbilityEnum.SpeedAbility:
                    Message = "Speed boost";
                    break;

                case AbilityEnum.StrengthAbility:
                    Message = "Strength boost";
                    break;

                case AbilityEnum.ThiccnessAbility:
                    Message = "Stamina boost";
                    break;

                case AbilityEnum.StaminaAbility:
                    Message = "Stamina boost";
                    break;
                case AbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}