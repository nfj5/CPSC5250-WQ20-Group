using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Models
{
    public class CharacterModel: PersonModel<CharacterModel>
    {
        /// <summary>
        /// Default character
        /// </summary>
        public CharacterModel()
        {
            PersonType = PersonTypeEnum.Character;
            Name = "Bob Joe";
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

        /// <summary>
        /// Default characters
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