using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;

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

    }
}