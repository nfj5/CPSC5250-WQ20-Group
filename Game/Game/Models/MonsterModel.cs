using System;
namespace Game.Models
{

    public class MonsterModel: BaseModel<MonsterModel>
    {
        // Private attributes
        private const int MAX_ITEMS = 6;

        public int BaseSpeed { get; set; } = 0;// How quickly the character can move (max number of blocks per turn). Scale of 1-4
        public int BaseStrength { get; set; } = 0;// How far the Person can throw Items. Scale of 1-4
        public int BaseHitPoints { get; set; } = 0; // How much damage the character can take. Scale of 10-20
        public int BaseThiccness { get; set; } = 0;// How much defense a character can have.
        public int BaseStamina { get; set; } = 0; 
        // How much stamina the character has, on a 1 –99 scale. Stamina resets after matches, stamina determines run duration, number of throws.
        //If not enough stamina then the user can not perform any actions. A math is 1 game(or 1 dungeon, or 1 round however you want to think of it).
        // Also different actions take different amount of stamina so we are not assuming a character will get 99 turns.  

        public int CurrentSpeed { get; set; } = 0;// How quickly the character can currently move
        public int CurrentStrength { get; set; } = 0; // How strong the character currently is
        public int CurrentHitPoints { get; set; } = 0;// How much damage the character can currently take
        public int CurrentCooldown { get; set; } = 0;// The current cooldown time of the characters special ability
        public int CurrentThiccness { get; set; } = 0; //The current thicness level of the character. 
        public int CurrentStamina { get; set; } = 0;// How much stamina the character currently has during their turn

        new public string Name { get; set; } = "Character Name"; // The official name for the Person. Not editable by the player 
        public string Nickname { get; set; } = "Character Nickname"; // The player-editable name for the Person 
        public AbilityModel SuperstarAbility { get; set; } // uses separate Ability class which applies modifiers to the Character, tracks ability cooldown, et cetera 
        
        public int TrainingPoints { get; set; } = 0; // Points used to upgrade speed, strength, hit_points, stamina.  
        public List<ItemModel> Items { get; set; } = new List<ItemModel>(); // Return list of all items the character currently has on its persons. 
        new public string ImageURI { get; set; } = CharacterService.DefaultImageURI; // The image to use for this Person

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

            CurrentSpeed = (int) Math.Floor(BaseSpeed * SuperstarAbility.SpeedMultiplier);
            CurrentStrength = (int) Math.Floor(BaseStrength * SuperstarAbility.StrengthMultiplier);
            CurrentHitPoints = (int) Math.Floor(BaseHitPoints * SuperstarAbility.HitPointModifier);
            CurrentThiccness = (int) Math.Floor(BaseThiccness * SuperstarAbility.ThiccnessModifier);

            CurrentCooldown = SuperstarAbility.Cooldown;

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

        //Attributes 
        public int CooldownTime { get; set; } // cooldown will be number of turns 
        public float Modifier { get; set; } // multiplier to be applied to the specified stat. Result will be rounded down. The stat modified will depend on which special ability was given to the character at time of creation. We will have 3 different special abilities. The stats being modified are speed, strength, and stamina.  

        public override void Update(CharacterModel newData)
        {
            if (newData == null)
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