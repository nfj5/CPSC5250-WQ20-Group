using Game.Helpers;
using Game.Services;
using Game.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using Game.Models;

namespace Game.Models
{
    /// <summary>
    /// Base Person model that Characters and Monster derive from
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersonModel<T> : BaseModel<T>
    {
        [Ignore]
        public int ListOrder { get; set; } = 0;

        // alive status, !alive will be removed from the list
        [Ignore]
        public bool Alive { get; set; } = true;

        // Level of character or monster
        public int Level { get; set; } = 1;

        // To denote which kind of Person this model is being used as
        public PersonTypeEnum PersonType { get; set; }

        // Where the Item goes on the character.  Head, Foot etc.
        public PersonJobEnum PersonJob { get; set; } = PersonJobEnum.Unknown;

        // The amount of experience that the Person has
        public int ExperiencePoints { get; set; } = 0;

        // Private attributes
        private const int MAX_ITEMS = 6; // How many Items the Character is able to hold at once

        public int BaseSpeed { get; set; } = 1;// How quickly the character can move (max number of blocks per turn). Scale of 1-5
        public int BaseStrength { get; set; } = 1;// How far the Person can throw Items. Scale of 1-9
        public int BaseHitPoints { get; set; } = 10; // How much damage the character can take. Scale of 10-20
        public int BaseThiccness { get; set; } = 5;// How much defense a character can have.
        public int BaseStamina { get; set; } = 7;
        // How much stamina the character has, on a 1 –99 scale. Stamina resets after matches, stamina determines run duration, number of throws.
        // If not enough stamina then the user can not perform any actions. A math is 1 game(or 1 dungeon, or 1 round however you want to think of it).
        // Also different actions take different amount of stamina so we are not assuming a character will get 99 turns.  

        public int CurrentSpeed { get; set; }// How quickly the character can currently move
        public int CurrentStrength { get; set; } = 1; // How strong the character currently is
        public int CurrentHitPoints { get; set; } // How much damage the character can currently take
        public int CurrentThiccness { get; set; } //The current thicness level of the character. 
        public int CurrentStamina { get; set; } // How much stamina the character currently has during their turn

        new public string Name { get; set; } = "Character Name"; // The official name for the Person. Not editable by the player 
        public string Nickname { get; set; } = "Character Nickname"; // The player-editable name for the Person 

        // Ability code
        public AbilityEnum Ability { get; set; } // To decide which stat to apply the ability to
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

        [Ignore]
        // Return the Damage value, it is 25% of the Level rounded up
        public int GetDamageLevelBonus { get { return Convert.ToInt32(Math.Ceiling(Level * .25)); } }

        //Public methods

        /// <summary>
        /// Have the Person drop the item at the corresponding inventory index if it exists
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add the ItemModel to the Person's inventory if they are at not carrying capacity
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Check if the SuperstarAbility is on cooldown and applies modifiers if not on cooldown
        /// </summary>
        /// <returns></returns>
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
                case AbilityEnum.SpeedAbility:
                    CurrentSpeed = (int)(CurrentSpeed * SuperstarModifier);
                    break;
                case AbilityEnum.StaminaAbility:
                    CurrentStamina = (int)(CurrentStamina * SuperstarModifier);
                    break;
                case AbilityEnum.StrengthAbility:
                    CurrentStrength = (int)(CurrentStrength * SuperstarModifier);
                    break;
                case AbilityEnum.ThiccnessAbility:
                    CurrentThiccness = (int)(CurrentThiccness * SuperstarModifier);
                    break;
            }

            CurrentCooldown = BaseCooldown;

            return true;
        }

        /// <summary>
        /// This move will handle automatic actions that occur every turn, such as ability cooldown
        /// </summary>
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

        /// <summary>
        /// Check to see if the Person has enough stamina currently to perform an action
        /// </summary>
        /// <param name="actionCost"></param>
        /// <returns></returns>
        public bool CheckStamina(int actionCost)
        {
            return (CurrentStamina - actionCost >= 0);
        }

        /// <summary>
        /// Update the Person's CurrentStamina with the cost of performing a specific action
        /// </summary>
        /// <param name="actionCost"></param>
        public void UpdateStamina(int actionCost)
        {
            CurrentStamina -= actionCost;
        }

        /// <summary>
        /// Check if the SuperstarAbility is on cooldown
        /// </summary>
        /// <returns></returns>
        public bool CheckCooldown()
        {
            return (CurrentCooldown != 0);
        }

        /// <summary>
        /// Roll the Damage Dice, and add to the Damage
        /// </summary>
        /// <returns></returns>
        public int GetDamageRollValue()
        {
            var myReturn = 0;

            //Come back and do something about using other items. 
            var myItem = ItemIndexViewModel.Instance.GetItem(ItemOne);
            if (myItem != null)
            {
                // Dice of the weapon.  So sword of Damage 10 is d10
                myReturn += DiceHelper.RollDice(1, myItem.Damage);
            }

            // Add in the Level as extra damage per game rules
            myReturn += GetDamageLevelBonus;

            return myReturn;
        }

        /// <summary>
        /// Take Damage
        /// If the damage recived, is > health, then death occurs
        /// Return the number of experience received for this attack 
        /// monsters give experience to characters.  Characters don't accept expereince from monsters
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHitPoints = CurrentHitPoints - damage;
            if (CurrentHitPoints <= 0)
            {
                CurrentHitPoints = 0;

                // Death...
                CauseDeath();
            }

            return true;
        }

        /// <summary>
        /// Death
        /// Alive turns to False
        /// </summary>
        /// <returns></returns>
        public bool CauseDeath()
        {
            Alive = false;
            return Alive;
        }

        /// <summary>
        /// Remove ItemModel from a set location
        /// Does this by adding a new ItemModel of Null to the location
        /// This will return the previous ItemModel, and put null in its place
        /// Returns the ItemModel that was at the location
        /// Nulls out the location
        /// </summary>
        /// <param name="itemlocation"></param>
        /// <returns></returns>
        public ItemModel RemoveItem(ItemLocationEnum itemlocation)
        {
            var myReturn = AddItem(itemlocation, null);

            // Save Changes
            return myReturn;
        }


        /// <summary>
        /// Drop All Items
        /// Return a list of items for the pool of items
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropAllItems()
        {
            var myReturn = new List<ItemModel>();

            // Drop all Items
            ItemModel myItem;

            myItem = RemoveItem(ItemLocationEnum.ItemOne);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.ItemTwo);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.ItemThree);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.ItemFour);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.ItemFive);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.ItemSix);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            return myReturn;
        }

        public string FormatOutput() { return ""; }

        /// <summary>
        /// Add ItemModel
        /// Looks up the ItemModel
        /// Puts the ItemModel ID as a string in the location slot
        /// If ItemModel is null, then puts null in the slot
        /// Returns the ItemModel that was in the location
        /// </summary>
        /// <param name="itemLocation"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ItemModel AddItem(ItemLocationEnum itemLocation, string itemID)
        {
            var myReturn = GetItemByLocation(itemLocation);

            switch (itemLocation)
            {
                case ItemLocationEnum.ItemOne:
                    ItemOne = itemID;
                    break;

                case ItemLocationEnum.ItemTwo:
                    ItemTwo = itemID;
                    break;

                case ItemLocationEnum.ItemThree:
                    ItemThree = itemID;
                    break;

                case ItemLocationEnum.ItemFour:
                    ItemFour = itemID;
                    break;

                case ItemLocationEnum.ItemFive:
                    ItemFive = itemID;
                    break;

                case ItemLocationEnum.ItemSix:
                    ItemSix = itemID;
                    break;

                default:
                    myReturn = null;
                    break;
            }

            return myReturn;
        }

        /// <summary>
        /// Get the ItemModel at a known string location (head, foot etc.)
        /// </summary>
        /// <param name="itemLocation"></param>
        /// <returns></returns>
        public ItemModel GetItemByLocation(ItemLocationEnum itemLocation)
        {
            switch (itemLocation)
            {
                case ItemLocationEnum.ItemOne:
                    return GetItem(1);

                case ItemLocationEnum.ItemTwo:
                    return GetItem(2);

                case ItemLocationEnum.ItemThree:
                    return GetItem(3);

                case ItemLocationEnum.ItemFour:
                    return GetItem(4);

                case ItemLocationEnum.ItemFive:
                    return GetItem(5);

                case ItemLocationEnum.ItemSix:
                    return GetItem(6);

                
            }

            return null;
        }
    }

}