using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Game.Models
{
    public class CharacterModel: PersonModel<CharacterModel>
    {

        public CharacterModel()
        {
            PersonType = PersonTypeEnum.Character;
            Name = "Bob Joe";
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

        public CharacterModel(int num)
        {
            PersonType = PersonTypeEnum.Character;
            Name = "Character " + num;
            Description = "A basic Footbrawler";
            ImageURI = "football_charcter.png";
        }

    }
}