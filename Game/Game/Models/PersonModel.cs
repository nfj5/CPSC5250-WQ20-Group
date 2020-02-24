using Game.Services;
using Game.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Base Person model that Characters and Monster derive from
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersonModel<T> : BaseModel<T>
    {
        // SuperstarAbility enum declaration
        public enum SuperstarAbility
        {
            SpeedAbility,
            StrengthAbility,
            ThiccnessAbility,
            StaminaAbility
        };

        [Ignore]
        public int ListOrder { get; set; } = 0;

        // alive status, !alive will be removed from the list
        [Ignore]
        public bool Alive { get; set; } = true;

        // Level of character or monster
        public int Level { get; set; } = 1;

        // To denote which kind of Person this model is being used as
        public PersonTypeEnum PersonType { get; set; }

        // The amount of experience that the Person has
        public int ExperiencePoints { get; set; } = 0;

        // Private attributes
        private const int MAX_ITEMS = 6; // How many Items the Character is able to hold at once

        public int BaseSpeed { get; set; } = 0;// How quickly the character can move (max number of blocks per turn). Scale of 1-5
        public int BaseStrength { get; set; } = 0;// How far the Person can throw Items. Scale of 1-9
        public int BaseHitPoints { get; set; } = 0; // How much damage the character can take. Scale of 10-20
        public int BaseThiccness { get; set; } = 0;// How much defense a character can have.
        public int BaseStamina { get; set; } = 0;
        // How much stamina the character has, on a 1 –99 scale. Stamina resets after matches, stamina determines run duration, number of throws.
        // If not enough stamina then the user can not perform any actions. A math is 1 game(or 1 dungeon, or 1 round however you want to think of it).
        // Also different actions take different amount of stamina so we are not assuming a character will get 99 turns.  

        public int CurrentSpeed { get; set; } = 0;// How quickly the character can currently move
        public int CurrentStrength { get; set; } = 0; // How strong the character currently is
        public int CurrentHitPoints { get; set; } = 0;// How much damage the character can currently take
        public int CurrentThiccness { get; set; } = 0; //The current thicness level of the character. 
        public int CurrentStamina { get; set; } = 0;// How much stamina the character currently has during their turn

        new public string Name { get; set; } = "Character Name"; // The official name for the Person. Not editable by the player 
        public string Nickname { get; set; } = "Character Nickname"; // The player-editable name for the Person 

        // Ability code
        public SuperstarAbility Ability { get; set; } // To decide which stat to apply the ability to
        public float SuperstarModifier { get; set; } // The actual modifier for the ability
        public int BaseCooldown { get; set; } // How long it should take before the ability can be used again
        public int CurrentCooldown { get; set; } = 0; // The current cooldown time (in units of turns taken) of the characters special ability

        public int TrainingPoints { get; set; } = 0; // Points used to upgrade speed, strength, hit_points, stamina.
        new public string ImageURI { get; set; } = CharacterService.DefaultImageURI; // The image to use for this Person

        public int NumItems { get; set; } = 0; // Keep track of how many items the Character is currently holding

        // Strings to hold the GUID of each item for each slot
        public string ItemOne { get; set; } = null;
        public string ItemTwo { get; set; } = null;
        public string ItemThree { get; set; } = null;
        public string ItemFour { get; set; } = null;
        public string ItemFive { get; set; } = null;
        public string ItemSix { get; set; } = null;

        //Public methods

        // Have the Person drop the item at the corresponding inventory index if it exists
        public ItemModel RemoveItem(int index)
        {
            ItemModel item = GetItem(index);

            if (item == null)
            {
                return null;
            }

            switch (index)
            {
                case 1:
                    ItemOne = null;
                    break;
                case 2:
                    ItemTwo = null;
                    break;
                case 3:
                    ItemThree = null;
                    break;
                case 4:
                    ItemFour = null;
                    break;
                case 5:
                    ItemFive = null;
                    break;
                case 6:
                    ItemSix = null;
                    break;
            }

            NumItems--;
            return item;
        }

        // Add the ItemModel to the Person's inventory if they are at not carrying capacity
        public bool AddItem(ItemModel toAdd)
        {
            if (NumItems == MAX_ITEMS)
            {
                return false;
            }

            switch (NumItems + 1)
            {
                case 1:
                    ItemOne = toAdd.Id;
                    break;
                case 2:
                    ItemTwo = toAdd.Id;
                    break;
                case 3:
                    ItemThree = toAdd.Id;
                    break;
                case 4:
                    ItemFour = toAdd.Id;
                    break;
                case 5:
                    ItemFive = toAdd.Id;
                    break;
                case 6:
                    ItemSix = toAdd.Id;
                    break;
            }

            NumItems++;
            return true;
        }

        /// <summary>
        /// Get the ItemModel for the item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ItemModel GetItem(int index)
        {
            if (NumItems < index || index < 1)
            {
                return null;
            }

            string item = null;
            switch (index)
            {
                case 1:
                    item = ItemOne;
                    break;
                case 2:
                    item = ItemTwo;
                    break;
                case 3:
                    item = ItemThree;
                    break;
                case 4:
                    item = ItemFour;
                    break;
                case 5:
                    item = ItemFive;
                    break;
                case 6:
                    item = ItemSix;
                    break;
            }

            if (item == null)
            {
                return null;
            }

            return ItemIndexViewModel.Instance.GetItem(item);
        }

        // Check if the SuperstarAbility is on cooldown and applies modifiers if not on cooldown
        public bool ActivateAbility()
        {
            if (PersonType == PersonTypeEnum.Monster)
            {
                return false;
            }

            if (CheckCooldown())
            {
                return false;
            }

            switch (Ability)
            {
                case SuperstarAbility.SpeedAbility:
                    CurrentSpeed = (int)(CurrentSpeed * SuperstarModifier);
                    break;
                case SuperstarAbility.StaminaAbility:
                    CurrentStamina = (int)(CurrentStamina * SuperstarModifier);
                    break;
                case SuperstarAbility.StrengthAbility:
                    CurrentStrength = (int)(CurrentStrength * SuperstarModifier);
                    break;
                case SuperstarAbility.ThiccnessAbility:
                    CurrentThiccness = (int)(CurrentThiccness * SuperstarModifier);
                    break;
            }

            CurrentCooldown = BaseCooldown;

            return true;
        }

        // This move will handle automatic actions that occur every turn, such as ability cooldown
        public void TurnManager()
        {
            if (!CheckCooldown())
            {
                CurrentCooldown--;
            }
            else
            {
                CurrentSpeed = BaseSpeed;
                CurrentStamina = BaseStamina;
                CurrentHitPoints = BaseHitPoints;
                CurrentThiccness = BaseThiccness;
            }
        }

        // Check to see if the Person has enough stamina currently to perform an action
        public bool CheckStamina(int actionCost)
        {
            return (CurrentStamina - actionCost >= 0);
        }

        // Update the Person's CurrentStamina with the cost of performing a specific action
        public void UpdateStamina(int actionCost)
        {
            CurrentStamina -= actionCost;
        }

        // Check if the SuperstarAbility is on cooldown
        public bool CheckCooldown()
        {
            return (CurrentCooldown != 0);
        }

    }
}