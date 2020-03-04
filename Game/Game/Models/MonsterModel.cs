using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// The Monsters in the Game
    /// 
    /// Derives from Person Model just like Character
    /// </summary>
    public class MonsterModel : PersonModel<MonsterModel>
    {
        /// <summary>
        /// Empty constructor for default Monsters
        /// </summary>
        public MonsterModel()
        {
            PersonType = PersonTypeEnum.Monster;
            Name = "Bob Joe";
            Description = "A basic Footbrawler";
            ImageURI = "football_monster.png";
        }

        /// <summary>
        /// Constructor for default Monsters
        /// </summary>
        /// <param name="num"></param>
        public MonsterModel(int num)
        {
            PersonType = PersonTypeEnum.Monster;
            Name = "Monster " + num;
            Description = "A basic Footbrawler";
            ImageURI = "football_monster.png";
        }
    }
}