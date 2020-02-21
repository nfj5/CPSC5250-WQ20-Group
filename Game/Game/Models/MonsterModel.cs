using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;

namespace Game.Models
{
    public class MonsterModel : PersonModel<MonsterModel>
    {

        public MonsterModel()
        {
            PersonType = PersonTypeEnum.Monster;
            Name = "Bob Joe";
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

    }
}