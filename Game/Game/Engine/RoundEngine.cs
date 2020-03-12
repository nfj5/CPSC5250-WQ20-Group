using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Game.Helpers;
using Game.Models;

namespace Game.Engine
{

    /// <summary>
    /// Manages the Rounds
    /// </summary>
    public class RoundEngine : TurnEngine
    {
        private int MaxStartItems = 7;

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        /// <returns></returns>
        private bool ClearLists()
        {
            GameBoardModel.Wipe();
            ItemPool.Clear();
            MonsterList.Clear();
            return true;
        }
        /// <summary>
        /// Starts new round and populates gameboard with existing monsters, characters and items.
        /// </summary>
        /// <returns></returns>
        public bool NewRound()
        {
            // End the existing round
            EndRound();

            // Populate New Monsters...
            AddMonstersToRound();

            // Make the PlayerList
            MakePlayerList();

            // Populate the GameBoard
            PopulateGameBoard();

            // Update Score for the RoundCount
            BattleScore.RoundCount++;
            IsRound13();

            return true;
        }

        /// <summary>
        /// Hack number  33, Unlucky 13
        /// Kills a random character on the start of round 13.
        /// </summary>
   
        public  void IsRound13()
        {
            if (BattleScore.RoundCount == 13)
            {
                if (CharacterList.Count > 1)
                {
                    //Gets the remaining number of characters left.
                    int CharactertoKill = DiceHelper.RollDice(1, CharacterList.Count-1);
                    PlayerInfoModel character = CharacterList[CharactertoKill];
                    CharacterList.RemoveAt(CharactertoKill);
                    Debug.WriteLine("Character named: " + character.Name + "obliterated");
                }
            }
        }

        /// <summary>
        /// Create the Gameboard object and put Characters, Monsters and default Items.
        /// </summary>
        public void PopulateGameBoard()
        {
            // place characters on last row of the board
            int x = 0, y = 5;
            foreach(PlayerInfoModel character in CharacterList)
            {
                GameBoardModel.Place(character, x, y);
                Debug.WriteLine("[Character] Placed " + character.Name + " at (" + x + ", " + y + ")");
                x++;
            }

            // place monsters on first row of the board
            x = 0; y = 0; 
            foreach(PlayerInfoModel monster in MonsterList)
            {
                GameBoardModel.Place(monster, x, y);
                Debug.WriteLine("[Monster] Placed " + monster.Name + " at (" + x + ", " + y + ")");
                y++;
            }

            // place items randomly on board
            for (int i = 0; i < MaxStartItems; ++i)
            {
                x = DiceHelper.RollDice(1, 5);
                y = DiceHelper.RollDice(1, 5);

                var item = ItemHelper.GetRandomItem();
                if (!GameBoardModel.Place(item, x, y))
                {
                    --i;
                }

                Debug.WriteLine("[Item] Placed " + item.Name + " at (" + x + ", " + y + ")");
            }
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        /// </summary>
        /// <returns></returns>
        public int AddMonstersToRound()
        {
            for (var i = 0; i < MaxNumberPartyMonsters; i++)
            {
                var data = new MonsterModel();
                // Help identify which Monster it is
                data.Name += " " + MonsterList.Count() + 1;
                MonsterList.Add(new PlayerInfoModel(data));
            }

            return MonsterList.Count();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List and the MonsterModel List
        /// </summary>
        /// <returns></returns>
        public bool EndRound()
        {
            // Have each character pickup items...
            // Do not pick up Items at the end of the round
            //foreach (var character in CharacterList)
            //{
            //    PickupItemsFromPool(character);
            //}

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }

        /// <summary>
        /// Manages the next Turn
        /// 
        /// Decides Who's Turn is next and remembers Current Player
        /// 
        /// Then begin the next Turn
        /// 
        /// </summary>
        /// <returns></returns>
        public RoundEnum RoundNextTurn()
        {
            // No characters, game is over...
            if (CharacterList.Count < 1)
            {
                // Game Over
                RoundStateEnum = RoundEnum.GameOver;
                return RoundStateEnum;
            }

            // Check if round is over
            if (MonsterList.Count < 1)
            {
                // If over, New Round
                RoundStateEnum = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            // Decide Who gets next turn
            // Remember who just went...
            PlayerCurrent = GetNextPlayerTurn();
            Debug.WriteLine(PlayerCurrent.Name + "'s Turn");

            // Do the turn....
            TakeTurn(PlayerCurrent);

            RoundStateEnum = RoundEnum.NextTurn;

            return RoundStateEnum;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel GetNextPlayerTurn()
        {
            // Recalculate Order
            OrderPlayerListByTurnOrder();

            // Get Next Player
            var PlayerCurrent = GetNextPlayerInList();

            return PlayerCurrent;
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// 
        /// Order is based by... 
        /// Order by Speed (Desending)
        /// Then by Highest level (Descending)
        /// Then by Highest Experience Points (Descending)
        /// Then by Character before MonsterModel (enum assending)
        /// Then by Alphabetic on Name (Assending)
        /// Then by First in list order (Assending)
        /// </summary>
        public List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            // Work with the Class variable PlayerList
            PlayerList = MakePlayerList();

            PlayerList = PlayerList.OrderByDescending(a => a.CurrentSpeed)
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.ExperiencePoints)
                .ThenByDescending(a => a.PersonType)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.ListOrder)
                .ToList();

            return PlayerList;
        }

        /// <summary>
        /// Generate a Player list that determines who can play this round.
        /// </summary>
        public List<PlayerInfoModel> MakePlayerList()
        {
            // Start from a clean list of players
            PlayerList.Clear();

            // Remeber the Insert order, used for Sorting
            var ListOrder = 0;

            foreach (var data in CharacterList)
            {
                if (data.Alive)
                {
                    PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            foreach (var data in MonsterList)
            {
                if (data.Alive)
                {
                    PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            return PlayerList;
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel GetNextPlayerInList()
        {
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null
            if (PlayerList.Count == 0)
            {
                return null;
            }

            // No current player, so set the first one
            if (PlayerCurrent == null)
            {
                return PlayerList.FirstOrDefault();
            }

            // Find current player in the list
            //Commenting out untill we figuere out if we need a GUID. 
            var index = PlayerList.FindIndex(m => m.Guid.Equals(PlayerCurrent.Guid));

            // If at the end of the list, return the first element
            if (index == PlayerList.Count() - 1)
            {
                return PlayerList.FirstOrDefault();
            }

            // Return the next element
            return PlayerList[index + 1];

            //// Else go and pick the next player in the list...
            //for (var i = 0; i < PlayerCount; i++)
            //{
            //    // Look for current Player in the list
            //    if (PlayerList[i].Guid.Equals(PlayerCurrent.Guid))
            //    {
            //        if (i < PlayerList.Count() - 1) // 0 based...
            //        {
            //            return PlayerList[i + 1];
            //        }
            //        else
            //        {
            //            // Return the first in the list...
            //            return PlayerList.FirstOrDefault();
            //        }
            //    }
            //}

            //            return null;
        }

        /// <summary>
        /// Pickup Items Dropped and insert them back into the ItemPool.
        /// </summary>
        /// <param name="character"></param>
        public bool PickupItemsFromPool(PlayerInfoModel character)
        {
            // Have the character, walk the items in the pool, and decide if any are better than current one.

            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head); 

            return true;
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        public bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            var myList = ItemPool.Where(a => a.Location == setLocation)
                .OrderByDescending(a => a.Value)
                .ToList();

            // If no items in the list, return...
            if (!myList.Any())
            {
                return false;
            }

            var CharacterItem = character.GetItemByLocation(setLocation);
            if (CharacterItem == null)
            {
                // If no ItemModel in the slot then put on the first in the list
                character.AddItem(setLocation, myList.FirstOrDefault().Id);
                return true;
            }

            foreach (var PoolItem in myList)
            {
                if (PoolItem.Value > CharacterItem.Value)
                {
                    // Put on the new ItemModel, which drops the one back to the pool
                    var droppedItem = character.AddItem(setLocation, PoolItem.Id);

                    // Remove the ItemModel just put on from the pool
                    ItemPool.Remove(PoolItem);

                    if (droppedItem != null)
                    {
                        // Add the dropped ItemModel to the pool
                        ItemPool.Add(droppedItem);
                    }
                }
            }

            return true;
        }
    }
}