using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Game.Engine
{
    /* 
     * Need to decide who takes the next turn
     * Target to Attack
     * Should Move, or Stay put (can hit with weapon range?)
     * Death
     * Manage Round...
     */

    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// </summary>
    public class TurnEngine : BaseEngine
    {
        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm

        /// <summary>
        /// Perform a turn and attack the target
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool TakeTurn(PlayerInfoModel Attacker)
        {
            // Replenish Stamina
            Attacker.CurrentStamina = Attacker.BaseStamina;

            // Choose Action.  Such as Move, Attack etc.

            // while an action is possible
            // If Nearest enemy in range and have an item, then Attack
            // If in range of an item, then move onto Item

            // if we don't have an item
            if (Attacker.ItemOne == null)
            {
                // move to item
                int[] closestItem = GetClosestItem(Attacker);
                if (closestItem[0] != Int32.MaxValue && closestItem[1] != Int32.MaxValue)
                {
                    // Move towards the Item, conserving 3 stamina for the attack
                    Attacker.CurrentStamina = MoveTowards(Attacker, closestItem, 3, GameBoard.GetItem(closestItem[0], closestItem[1]).Name);
                }

                int[] PlayerLocation = GameBoard.GetPlayerLocation(Attacker);

                int[] newestClosest = GetClosestItem(Attacker);
                if (newestClosest[0] != Int32.MaxValue && newestClosest[1] != Int32.MaxValue &&
                    GameBoardHelper.Distance(newestClosest[0], newestClosest[1], PlayerLocation[0], PlayerLocation[1]) <= 1)
                {
                    ItemModel temp = GameBoard.ItemLocations[newestClosest[0], newestClosest[1]];
                    Attacker.ItemOne = temp.Id;
                    Debug.WriteLine(Attacker.Name + " picked up " + temp.Name);
                    GameBoard.ItemLocations[newestClosest[0], newestClosest[1]] = null;
                }
            }

            // then try an attack
            var attacks = Attack(Attacker);
            if (!attacks)
            {
                // move toward enemy
                int[] TargetLocation = AttackChoice(Attacker);

                if (TargetLocation[0] == Int32.MaxValue)
                {
                    return attacks;
                }

                Attacker.CurrentStamina = MoveTowards(Attacker, TargetLocation, 0, GameBoard.GetPlayer(TargetLocation[0], TargetLocation[1]).Name);
            }

            BattleScore.TurnCount++;

            return attacks;
        }

        /// <summary>
        /// Get the closest item to the specified Player
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int[] GetClosestItem(PlayerInfoModel player)
        {
            int[] PlayerLocation = GameBoard.GetPlayerLocation(player);
            int[] location = { Int32.MaxValue, Int32.MaxValue };

            // Get closest Character
            int closestDistance = Int32.MaxValue;
            for (int x = 0; x < GameBoardModel.Size; ++x)
            {
                for (int y = 0; y < GameBoardModel.Size; ++y)
                {
                    if (GameBoard.ItemLocations[x, y] != null)
                    {
                        int distance = GameBoardHelper.Distance(x, y, PlayerLocation[0], PlayerLocation[1]);
                        if (distance < closestDistance)
                        {
                            location[0] = x;
                            location[1] = y;
                        }
                    }
                }
            }

            return location;
        }

        /// <summary>
        /// Move towards the specified location as much as possible
        /// </summary>
        /// <param name="player"></param>
        /// <param name="location"></param>
        /// <param name="StaminaToConserve"></param>
        /// <returns></returns>
        public int MoveTowards(PlayerInfoModel player, int[] location, int StaminaToConserve, string label)
        {
            int[] PlayerLocation = GameBoard.GetPlayerLocation(player);
            int Distance = GameBoardHelper.Distance(location[0], location[1], PlayerLocation[0], PlayerLocation[1]);

            Debug.WriteLine("Distance " + Distance);

            // How far the Player can move when conserving the amount of stamina that they want to
            int CanMove = player.CurrentStamina - StaminaToConserve;

            if (CanMove < Distance) {
                Distance = CanMove;
            }
            
            // Determine how far to move in each direction
            int BlocksToMove = (int) (Math.Floor(Math.Sqrt(Math.Pow(Distance, 2) / 2)));
            int xMovement = (location[0] - PlayerLocation[0] > 0 ? BlocksToMove : -BlocksToMove);
            int yMovement = (location[1] - PlayerLocation[1] > 0 ? BlocksToMove : -BlocksToMove);

            // Debug.WriteLine("Move " + (PlayerLocation[0] + xMovement) + ", " + (PlayerLocation[1] + yMovement));

            int newX = PlayerLocation[0] + xMovement;
            if (PlayerLocation[0] + xMovement > 5 || PlayerLocation[0] + xMovement < 0)
            {
                newX = PlayerLocation[0];
            }

            int newY = PlayerLocation[1] + yMovement;
            if (PlayerLocation[1] + yMovement > 5 || PlayerLocation[1] + yMovement < 0)
            {
                newY = PlayerLocation[0];
            }

            // Perform the GameBoard updates
            GameBoard.PlayerLocations[PlayerLocation[0], PlayerLocation[1]] = null;
            GameBoard.PlayerLocations[newX, newY] = player;

            Debug.WriteLine(player.Name + " moved towards \"" + label + "\" (" + location[0] + ", " + location[1] + ")");

            // Update the Player stamina
            player.CurrentStamina -= BlocksToMove;
            return player.CurrentStamina;
        }

        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine the Attack score
        /// Determine the Defense score
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool Attack(PlayerInfoModel Attacker)
        {
            // For Attack, Choose Who
            var TargetLocation = AttackChoice(Attacker);

            if (TargetLocation[0] == Int32.MaxValue)
            {
                return false;
            }

            int[] attackerLocation = GameBoard.GetPlayerLocation(Attacker);
            int Distance = GameBoardHelper.Distance(attackerLocation[0], attackerLocation[1], TargetLocation[0], TargetLocation[1]);

            int AttackRange = 1;
            if (Attacker.ItemOne != null)
            {
                AttackRange = ItemIndexViewModel.Instance.GetItem(Attacker.ItemOne).Range;
            }

            if (Distance > AttackRange || Attacker.CurrentStamina < 3)
            {
                return false;
            }

            // Do Attack
            PlayerInfoModel TargetModel = GameBoard.GetPlayer(TargetLocation[0], TargetLocation[1]);
            TurnAsAttack(Attacker, TargetModel);

            CurrentAttacker = new PlayerInfoModel(Attacker);
            CurrentDefender = new PlayerInfoModel(TargetModel);

            return true;
        }

        /// <summary>
        /// Move as a Turn
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        public bool Move(PlayerInfoModel Person)
        {
            var Target = MoveChoice(Person);

            return true;
        }

        /// <summary>
        /// Decide where to move
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int[,] MoveChoice(PlayerInfoModel Person)
        {
            int[,] location = new int[1,1];
            return location;
        }

        /// <summary>
        /// Decide which to attack 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int[] AttackChoice(PlayerInfoModel data)
        {
            switch (data.PersonType)
            {
                case PersonTypeEnum.Monster:
                    return SelectCharacterToAttack(data);

                case PersonTypeEnum.Character:
                default:
                    return SelectMonsterToAttack(data);
            }
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        /// <returns></returns>
        public int[] SelectCharacterToAttack(PlayerInfoModel currentMonster)
        {
            int[] monsterLocation = GameBoard.GetPlayerLocation(currentMonster);
            int[] closestLocation = { Int32.MaxValue, Int32.MaxValue };

            if (CharacterList == null)
            {
                return null;
            }

            if (CharacterList.Count < 1)
            {
                return null;
            }

            // Get closest Character
            int closestDistance = Int32.MaxValue;
            for (int x = 0; x < GameBoardModel.Size; ++x)
            {
                for (int y = 0; y < GameBoardModel.Size; ++y)
                {
                    if (GameBoard.PlayerLocations[x,y] != null &&
                        GameBoard.PlayerLocations[x,y].PersonType == PersonTypeEnum.Character)
                    {

                        int distance = GameBoardHelper.Distance(x, y, monsterLocation[0], monsterLocation[1]);
                        if (distance < closestDistance)
                        {
                            closestLocation[0] = x;
                            closestLocation[1] = y;
                        }
                    }
                }
            }

            return closestLocation;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        /// <returns></returns>
        public int[] SelectMonsterToAttack(PlayerInfoModel currentPlayer)
        {
            int[] characterLocation = GameBoard.GetPlayerLocation(currentPlayer);
            int[] closestLocation = { Int32.MaxValue, Int32.MaxValue };

            if (MonsterList == null)
            {
                return null;
            }

            if (MonsterList.Count < 1)
            {
                return null;
            }

            // Get closest Character
            int closestDistance = Int32.MaxValue;
            for (int x = 0; x < GameBoardModel.Size; ++x)
            {
                for (int y = 0; y < GameBoardModel.Size; ++y)
                {
                    if (GameBoard.PlayerLocations[x, y] != null &&
                        GameBoard.PlayerLocations[x, y].PersonType == PersonTypeEnum.Monster)
                    {

                        int distance = GameBoardHelper.Distance(x, y, characterLocation[0], characterLocation[1]);
                        if (distance < closestDistance)
                        {
                            closestLocation[0] = x;
                            closestLocation[1] = y;
                        }
                    }
                }
            }

            return closestLocation;
        }

        /// <summary>
        /// Attack the Target this Turn
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="AttackScore"></param>
        /// <param name="Target"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        public bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            BattleMessagesModel.TurnMessage = string.Empty;
            BattleMessagesModel.TurnMessageSpecial = string.Empty;
            BattleMessagesModel.AttackStatus = string.Empty;

            BattleMessagesModel.PlayerType = PersonTypeEnum.Monster;

            var AttackScore = Attacker.Level + Attacker.CurrentStrength;
            var DefenseScore = Target.CurrentThiccness + Target.Level;

            // Choose who to attack

            BattleMessagesModel.TargetName = Target.Name;
            BattleMessagesModel.AttackerName = Attacker.Name;

            BattleMessagesModel.HitStatus = RollToHitTarget(AttackScore, DefenseScore);

            Debug.WriteLine(BattleMessagesModel.GetTurnMessage());

            // It's a Miss
            if (BattleMessagesModel.HitStatus == HitStatusEnum.Miss)
            {
                return true;
            }

            // It's a Hit
            if (BattleMessagesModel.HitStatus == HitStatusEnum.Hit)
            {
                int Damage = Attacker.CurrentStrength;

                //Calculate Damage
                if (Attacker.ItemOne != null)
                {

                    Damage = Attacker.CurrentStrength + ItemIndexViewModel.Instance.GetItem(Attacker.ItemOne).Value;

                    // Hackathon 43: Go SU RedHawks
                    if (ItemIndexViewModel.Instance.GetItem(Attacker.ItemOne).Description == "Go SU RedHawks")
                    {
                        // Inflict 2x damage
                        Damage *= 2;
                        Debug.WriteLine("Go SU!");

                    }
                }

                BattleMessagesModel.DamageAmount = Damage;

                Target.TakeDamage(BattleMessagesModel.DamageAmount);

                // Hackathon 25: Rebound Damage
                float chance = DiceHelper.RollDice(1, 100) / 100f;
                if (SettingsHelper.ReboundEnabled && chance >= SettingsHelper.REBOUND_CHANCE)
                {
                    int ReboundDamage = (int) (Damage / 2);
                    
                    // Don't allow the player to die from rebound damage, leave them with at least 1 hit point
                    if (Attacker.CurrentHitPoints - ReboundDamage <= 0)
                    {
                        ReboundDamage = Attacker.CurrentHitPoints - 1;
                    }

                    Debug.WriteLine("The attack rebounded! Took " + ReboundDamage + " damage!");
                    Attacker.TakeDamage(ReboundDamage);
                }
            }

            BattleMessagesModel.CurrentHealth = Target.CurrentHitPoints;
            BattleMessagesModel.TurnMessageSpecial = BattleMessagesModel.GetCurrentHealthMessage();

            //Check if Target is dead
            RemoveIfDead(Target);

            BattleMessagesModel.TurnMessage = Attacker.Name + BattleMessagesModel.AttackStatus + Target.Name + BattleMessagesModel.TurnMessageSpecial;
            Debug.WriteLine(BattleMessagesModel.TurnMessage);

            return true;
        }

        /// <summary>
        /// Checks if the Target has died.
        /// 
        /// process for dead Target.
        /// </summary>
        /// <param name="Target"></param>
        public bool RemoveIfDead(PlayerInfoModel Target)
        {
            // Check for alive
            if (Target.Alive == false)
            {
                TargetDied(Target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        /// <param name="Target"></param>
        public bool TargetDied(PlayerInfoModel Target)
        {
            // Mark Status in output
            BattleMessagesModel.TurnMessageSpecial = " and causes death";

            // Remove target from list

            // Using a switch so in the future additional PlayerTypes can be added (e.x: Boss...)
            switch (Target.PersonType)
            {
                case PersonTypeEnum.Character:
                    CharacterList.Remove(Target);

                    int[] CharacterLocation = GameBoard.GetPlayerLocation(Target);
                    GameBoard.PlayerLocations[CharacterLocation[0], CharacterLocation[1]] = null;

                    // Add the MonsterModel to the killed list
                    BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

                    // DropItems(Target);

                    return true;

                case PersonTypeEnum.Monster:
                default:
                    MonsterList.Remove(Target);

                    int[] Location = GameBoard.GetPlayerLocation(Target);
                    GameBoard.PlayerLocations[Location[0], Location[1]] = null;

                    // Add one to the monsters killed count...
                    BattleScore.MonsterSlainNumber++;

                    // Add the MonsterModel to the killed list
                    BattleScore.MonstersKilledList += Target.FormatOutput() + "\n";

                    // We don't do Item drops
                    // DropItems(Target);

                    return true;
            }
        }

        /// <summary>
        /// Drop equipped Items
        /// </summary>
        /// <param name="Target"></param>
        public int DropItems(PlayerInfoModel Target)
        {
            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....
            myItemList.AddRange(GetRandomMonsterItemDrops(BattleScore.RoundCount));

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                BattleMessagesModel.TurnMessageSpecial += " ItemModel " + ItemModel.Name + " dropped";
            }

            ItemPool.AddRange(myItemList);

            return myItemList.Count();
        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        public HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            var d20 = DiceHelper.RollDice(1, 20);

            if (d20 == 1)
            {
                // Force Miss
                BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                return BattleMessagesModel.HitStatus;
            }

            if (d20 == 20)
            {
                // Force Hit
                BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
                return BattleMessagesModel.HitStatus;
            }

            var ToHitScore = d20 + AttackScore;
            if (ToHitScore < DefenseScore)
            {
                BattleMessagesModel.AttackStatus = " misses ";
                // Miss
                BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                BattleMessagesModel.DamageAmount = 0;
                return BattleMessagesModel.HitStatus;
            }

            // Hit
            BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
            return BattleMessagesModel.HitStatus;
        }

        /// <summary>
        /// Gets Items dropped from Monsters randomly between 1 to 4 items from the ItemModel set
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // You decide how to drop monster items, level, etc.

            var NumberToDrop = DiceHelper.RollDice(1, round);

            var myList = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                myList.Add(new ItemModel());
            }
            return myList;
        }
    }
}