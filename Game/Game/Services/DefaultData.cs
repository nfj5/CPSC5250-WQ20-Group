﻿using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Smelly jersery",
                    Description = "Smells so bad the monster wont come near you",
                    ImageURI = "smelly_jersery.png",
                    Range = 0,
                    Damage = 9,
                    Weight = 9,
                    Value = 9,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Pad Lock",
                    Description = "Strong enough to lock anyone down",
                    ImageURI = "padlock.png",
                    Range = 0,
                    Damage = 0,
                    Weight = 3,
                    Value = 9,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Shoes",
                    Description = "No one will be able to catch you in these",
                    ImageURI = "shoe.png",
                    Range = 0,
                    Damage = 0,
                    Weight = 5,
                    Value = 9,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Protein Shake",
                    Description = "Drinking this make your grow stronger",
                    ImageURI = "protein_shake.png",
                    Range = 0,
                    Damage = 0,
                    Weight = 5,
                    Value = 9,
                    Location = ItemLocationEnum.Unknown,
                    Attribute = AttributeEnum.Attack},
            };

            return datalist;
        }

        /// <summary>
        /// Load the Default data for Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var datalist = new List<CharacterModel>()
            {
                new CharacterModel
                {
                    Name = "Bob Jones",
                    Nickname = "BJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 9,
                    BaseHitPoints = 9,
                    BaseStamina = 9,
                    BaseStrength = 9,
                    BaseThiccness = 9,
                },

                new CharacterModel
                {
                    Name = "Adam Jones",
                    Nickname = "AJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 1,
                    BaseStamina = 1,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new CharacterModel
                {
                    Name = "Derick Jones",
                    Nickname = "DJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 5,
                    BaseHitPoints = 5,
                    BaseStamina = 5,
                    BaseStrength = 5,
                    BaseThiccness = 5
                }

            };

            return datalist;
        }

        /// <summary>
        /// Load the Default data for Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel
                {
                    Name = "Bob Jones",
                    Nickname = "BJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 9,
                    BaseHitPoints = 9,
                    BaseStamina = 9,
                    BaseStrength = 9,
                    BaseThiccness = 9,
                },

                new MonsterModel
                {
                    Name = "Adam Jones",
                    Nickname = "AJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 1,
                    BaseStamina = 1,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new MonsterModel
                {
                    Name = "Derick Jones",
                    Nickname = "DJ",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    BaseSpeed = 5,
                    BaseHitPoints = 5,
                    BaseStamina = 5,
                    BaseStrength = 5,
                    BaseThiccness = 5
                }

            };

            return datalist;
        }

        /// <summary>
        /// Load the default Score data
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }
    }
}