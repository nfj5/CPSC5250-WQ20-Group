using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using Game.ViewModels;

namespace Game.Helpers
{
    class ItemHelper
    {
        public static ItemModel GetRandomItem()
        {
            int item = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count) - 1;
            return ItemIndexViewModel.Instance.Dataset[item];
        }
    }
}
