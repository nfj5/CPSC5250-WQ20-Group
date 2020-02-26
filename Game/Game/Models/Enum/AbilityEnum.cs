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
}