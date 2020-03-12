using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Models
{
    /// <summary>
    /// The Characters in the Game
    /// 
    /// Derives from Person Model just like Monsters
    /// </summary>
    public class CharacterModel: PersonModel<CharacterModel>
    {
        /// <summary>
        /// Empty constructor for default Characters
        /// </summary>
        public CharacterModel()
        {
            PersonType = PersonTypeEnum.Character;
            PersonJob = PersonJobEnum.QB;
            Name = "Bob Joe";
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

        /// <summary>
        /// Constructor for default Characters
        /// </summary>
        /// <param name="num"></param>
        public CharacterModel(int num)
        {
            PersonType = PersonTypeEnum.Character;
            Name = "Character " + num;
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

    }
}