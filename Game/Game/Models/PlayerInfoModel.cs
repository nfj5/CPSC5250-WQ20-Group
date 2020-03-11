using System;
namespace Game.Models
{
    /// <summary>
    /// Player for the game.
    /// 
    /// Either Monster or Character
    /// 
    /// Constructor Player to Player used a T in Round
    /// </summary>
    public class PlayerInfoModel : PersonModel<PlayerInfoModel>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PlayerInfoModel() { }

        /// <summary>
        /// Copy from one PlayerInfoModel into Another
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(PlayerInfoModel data)
        {
            
            PersonType = data.PersonType;
            Alive = data.Alive;
            ExperiencePoints = data.ExperiencePoints;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            BaseSpeed = data.CurrentSpeed;
            ImageURI = data.ImageURI;
            BaseHitPoints = data.CurrentHitPoints;

            //We dont have a max health at the moment. Might add later if needed.
            //MaxHealth = data.GetMaxHealthTotal;

            // Set the strings for the items
            ItemOne = data.ItemOne;
            ItemTwo = data.ItemTwo;
            ItemThree = data.ItemThree;
            ItemFour = data.ItemFour;
            ItemFive = data.ItemFive;
            ItemSix = data.ItemSix;
            
            
        }

        /// <summary>
        /// Create PlayerInfoModel from character
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(CharacterModel data)
        {

            PersonType = data.PersonType;
            Alive = data.Alive;
            ExperiencePoints = data.ExperiencePoints;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            BaseSpeed = data.BaseSpeed;
            BaseStamina = data.BaseStamina;
            BaseStrength = data.BaseStrength;
            BaseThiccness = data.BaseThiccness;
            BaseHitPoints = data.BaseHitPoints;
            CurrentCooldown = data.CurrentCooldown;
            CurrentHitPoints = data.CurrentHitPoints;
            CurrentStamina = data.CurrentStamina;
            CurrentStrength = data.CurrentStrength;
            CurrentSpeed = data.CurrentSpeed;
            CurrentThiccness = data.CurrentThiccness;
            ImageURI = data.ImageURI;
           

            //We dont have a max health at the moment. Might add later if needed.
            //MaxHealth = data.GetMaxHealthTotal;

            // Set the strings for the items
            ItemOne = data.ItemOne;
            ItemTwo = data.ItemTwo;
            ItemThree = data.ItemThree;
            ItemFour = data.ItemFour;
            ItemFive = data.ItemFive;
            ItemSix = data.ItemSix;

        }

        /// <summary>
        /// Crate PlayerInfoModel from Monster
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(MonsterModel data)
        {

            PersonType = data.PersonType;
            Alive = data.Alive;
            ExperiencePoints = data.ExperiencePoints;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            BaseSpeed = data.BaseSpeed;
            BaseStamina = data.BaseStamina;
            BaseStrength = data.BaseStrength;
            BaseThiccness = data.BaseThiccness;
            BaseHitPoints = data.BaseHitPoints;
            CurrentCooldown = data.CurrentCooldown;
            CurrentHitPoints = data.CurrentHitPoints;
            CurrentStamina = data.CurrentStamina;
            CurrentStrength = data.CurrentStrength;
            CurrentSpeed = data.CurrentSpeed;
            CurrentThiccness = data.CurrentThiccness;
            ImageURI = data.ImageURI;
            

            // Set the strings for the items
            ItemOne = data.ItemOne;
            ItemTwo = data.ItemTwo;
            ItemThree = data.ItemThree;
            ItemFour = data.ItemFour;
            ItemFive = data.ItemFive;
            ItemSix = data.ItemSix;

        }
    }
}
