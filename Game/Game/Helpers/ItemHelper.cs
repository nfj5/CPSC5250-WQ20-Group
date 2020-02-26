using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using Game.ViewModels;

namespace Game.Helpers
{
    class ItemHelper
    {
        /// <summary>
        /// Selects a random item from a list of items
        /// </summary>
        /// <returns></returns>
        public static ItemModel GetRandomItem()
        {
            int item = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count) - 1;
            return ItemIndexViewModel.Instance.Dataset[item];
        }
    }
}
