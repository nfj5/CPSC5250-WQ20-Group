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
            ImageURI = "football_monster.png";
        }

        public MonsterModel(int num)
        {
            PersonType = PersonTypeEnum.Monster;
            Name = "Monster " + num;
            Description = "A basic Footbrawler";
            ImageURI = "football_monster.png";
        }
    }
}