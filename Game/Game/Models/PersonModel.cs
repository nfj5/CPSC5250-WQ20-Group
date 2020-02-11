using System.Collections.Generic;

namespace Game.Models
{

    public class PersonModel
    {
        public string Name { get; set; } // The official name for the Character. Not editable by the player 
        public string Nickname { get; set; } // The player-editable name for the Character 
        public Ability SuperstarAbility { get; set; } // uses separate Ability class which applies modifiers to the Character, tracks ability cooldown, et cetera 
        public int Speed { get; set; } // The speed the character can move, on a 1-99 scale. 
        public int Strength { get; set; } // The strength of the character, higher strength = further item can be throw, on a 1-99 scale. 
        public int HitPoints { get; set; } // How much total damage the character can take before dying, on a 1-99 scale.  
        public int MaxStamina { get; set; } // How much stamina the character has, on a 1 –99 scale. Stamina resets after matches, stamina determines run duration, number of throws. If not enough stamina then the user can not perform any actions. A math is 1 game(or 1 dungeon, or 1 round however you want to think of it). Also different actions take different amount of stamina so we are not assuming a character will get 99 turns.  
        public int CurrentStamina { get; set; } // How much stamina the character currently has during their turn
        public int TrianingPoints { get; set; } = 0; // Points used to upgrade speed, strength, hit_points, stamina.  
        public List<ItemModel> Items { get; set; } // Return list of all items the character currently has on its persons. 

        //Methods 
        public ItemModel RemoveItem(int index); // function to drop items 
        public bool AddItem(ItemModel to_add); // function to pick up items 
        public bool ActivateAbility();  // Checks if the superstar ability is on cool down and applies the modifier if not on cooldown 
        public void TurnManager(); // This method will calculate how much stamina is required for the user to conduct the moves it wants, if enough stamina is there then the move will be executed.
        public bool CheckStamina();// check if the character has enough stamina to conduct the move the user wants. 
        public void UpdateStamina(); // Updates the stamina field after the character turns. 
        public bool CheckCooldown(); // if ability is on cooldown 

        //Attributes 
        public int CooldownTime { get; set; } // cooldown will be number of turns 
        public float Modifier { get; set; } // multiplier to be applied to the specified stat. Result will be rounded down. The stat modified will depend on which special ability was given to the character at time of creation. We will have 3 different special abilities. The stats being modified are speed, strength, and stamina.  
    }
}