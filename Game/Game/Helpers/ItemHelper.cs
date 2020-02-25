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
            List<ItemModel> defaults = ItemIndexViewModel.Instance.GetDefaultData();
            int item = DiceHelper.RollDice(1, defaults.Count) - 1;
            return defaults[item];
        }
    }
}
