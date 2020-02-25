using Game.Models;
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
                    Value = 9,
                    Location = ItemLocationEnum.ItemOne,
                    Attribute = AttributeEnum.CurrentHealth},

                new ItemModel {
                    Name = "Pad Lock",
                    Description = "Strong enough to lock anyone down",
                    ImageURI = "padlock.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.ItemOne,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Shoes",
                    Description = "No one will be able to catch you in these",
                    ImageURI = "shoe.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.ItemOne,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Protein Shake",
                    Description = "Drinking this will make you gorw stronger",
                    ImageURI = "protein_shake.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.ItemOne,
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
                    ImageURI = "football_charcter.png",
                    BaseSpeed = 9,
                    BaseHitPoints = 9,
                    BaseStamina = 7,
                    BaseStrength = 1,
                    BaseThiccness = 1,
                },

                new CharacterModel
                {
                    Name = "Adam Jones",
                    Nickname = "AJ",
                    ImageURI = "football_charcter.png",
                    Level = 1,
                    BaseSpeed = 1,
                    BaseStamina = 7,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new CharacterModel
                {
                    Name = "Derick Jones",
                    Nickname = "DJ",
                    ImageURI = "football_charcter.png",
                    Level = 2,
                    BaseSpeed = 5,
                    BaseHitPoints = 5,
                    BaseStamina = 7,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new CharacterModel
                {
                    Name = "Aaron Jones",
                    Nickname = "AJ",
                    ImageURI = "football_charcter.png",
                    Level = 1,
                    BaseSpeed = 4,
                    BaseHitPoints = 9,
                    BaseStamina = 7,
                    BaseStrength = 1,
                    BaseThiccness = 1,
                },

                new CharacterModel
                {
                    Name = "Sam Jones",
                    Nickname = "SJ",
                    ImageURI = "football_charcter.png",
                    Level = 1,
                    BaseSpeed = 5,
                    BaseStamina = 7,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new CharacterModel
                {
                    Name = "Kane Jones",
                    Nickname = "KJ",
                    ImageURI = "football_charcter.png",
                    Level = 2,
                    BaseSpeed = 6,
                    BaseHitPoints = 5,
                    BaseStamina = 7,
                    BaseStrength = 1,
                    BaseThiccness = 1
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
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 2,
                    BaseHitPoints = 1,
                    BaseStamina = 10,
                    BaseStrength = 1,
                    BaseThiccness = 1,
                },

                new MonsterModel
                {
                    Name = "Adam Jones",
                    Nickname = "AJ",
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 3,
                    BaseStamina = 10,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new MonsterModel
                {
                    Name = "Derick Jones",
                    Nickname = "DJ",
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 5,
                    BaseHitPoints = 1,
                    BaseStamina = 10,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new MonsterModel
                {
                    Name = "Aaron Jones",
                    Nickname = "AJ",
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 9,
                    BaseHitPoints = 1,
                    BaseStamina = 10,
                    BaseStrength = 1,
                    BaseThiccness = 1,
                },

                new MonsterModel
                {
                    Name = "Sam Jones",
                    Nickname = "SJ",
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 1,
                    BaseStamina = 10,
                    BaseHitPoints = 1,
                    BaseStrength = 1,
                    BaseThiccness = 1
                },

                new MonsterModel
                {
                    Name = "Kane Jones",
                    Nickname = "KJ",
                    ImageURI = "football_monster.png",
                    Level = 2,
                    BaseSpeed = 4,
                    BaseHitPoints = 1,
                    BaseStamina = 10,
                    BaseStrength = 1,
                    BaseThiccness = 1
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