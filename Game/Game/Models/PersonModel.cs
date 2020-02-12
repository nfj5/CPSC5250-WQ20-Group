using System;
using System.Collections.Generic;

namespace Game.Models
{

    public class PersonModel
    {
        // Private attributes
        private const int MAX_ITEMS = 6;

        private int MaxSpeed { get; set; } // How quickly the character can move (max number of blocks per turn). Scale of 1-4
        private int MaxStrength { get; set; } // How far the Person can throw Items. Scale of 1-4
        private int MaxHitPoints { get; set; } // How much damage the character can take. Scale of 10-20

        private int CurrentSpeed { get; set; } // How quickly the character can currently move
        private int CurrentStrength { get; set; } // How strong the character currently is
        private int CurrentHitPoints { get; set; } // How much damage the character can currently take
        private int CurrentCooldown { get; set; }

        public string Name { get; set; } // The official name for the Person. Not editable by the player 
        public string Nickname { get; set; } // The player-editable name for the Person 
        public AbilityModel SuperstarAbility { get; set; } // uses separate Ability class which applies modifiers to the Character, tracks ability cooldown, et cetera 
        public int MaxStamina { get; set; } // How much stamina the character has, on a 1 –99 scale. Stamina resets after matches, stamina determines run duration, number of throws. If not enough stamina then the user can not perform any actions. A math is 1 game(or 1 dungeon, or 1 round however you want to think of it). Also different actions take different amount of stamina so we are not assuming a character will get 99 turns.  
        public int CurrentStamina { get; set; } // How much stamina the character currently has during their turn
        public int TrainingPoints { get; set; } = 0; // Points used to upgrade speed, strength, hit_points, stamina.  
        public List<ItemModel> Items { get; set; } // Return list of all items the character currently has on its persons. 
        public string ImageURI { get; set; } // The image to use for this Person

        //Public methods

        // Have the Person drop the item at the corresponding inventory index if it exists
        public ItemModel RemoveItem(int index)
        {
            if (Items.Count - 1 < index)
            {
                return null;
            }

            ItemModel item = Items[index];
            Items.RemoveAt(index);

            return item;
        }

        // Add the ItemModel to the Person's inventory if they are at not carrying capacity
        public bool AddItem(ItemModel toAdd)
        {
            if (Items.Count == MAX_ITEMS)
            {
                return false;
            }

            Items.Add(toAdd);
            return true;
        } 

        // Check if the SuperstarAbility is on cooldown and applies modifiers if not on cooldown
        public bool ActivateAbility()
        {
            if (CheckCooldown())
            {
                return false;
            }

            CurrentSpeed = (int) Math.Floor(MaxSpeed * SuperstarAbility.SpeedMultiplier);
            CurrentStrength = (int) Math.Floor(MaxStrength * SuperstarAbility.StrengthMultiplier);
            CurrentHitPoints = (int) Math.Floor(MaxHitPoints * SuperstarAbility.HitPointModifier);
            
            CurrentCooldown = SuperstarAbility.Cooldown;

            return true;
        }

        // This move will handle automatic actions that occur every turn, such as ability cooldown
        public void TurnManager()
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown--;
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

        //Attributes 
        public int CooldownTime { get; set; } // cooldown will be number of turns 
        public float Modifier { get; set; } // multiplier to be applied to the specified stat. Result will be rounded down. The stat modified will depend on which special ability was given to the character at time of creation. We will have 3 different special abilities. The stats being modified are speed, strength, and stamina.  
    }
}