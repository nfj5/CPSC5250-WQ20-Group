using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        AutoBattleEngine AutoBattleEngine;
        BattleEngine BattleEngine;

        [SetUp]
        public void Setup()
        {
            //AutoBattleEngine = EngineViewModel.AutoBattleEngine;
            BattleEngine = EngineViewModel.Engine;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void HakathonScenario_Constructor_0_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert
           

            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_1_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = -1, // Will go last...
                                Level = 1,
                                BaseHitPoints = 1,
                                ExperiencePoints = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters


            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, AutoBattleEngine.BattleScore.RoundCount);
        }

        [Test]
        public void HackathonScenario_Scenario_2_Character_Bob_Should_Miss()
        {
            /* 
             * Scenario Number:  
             *  2
             *  
             * Description: 
             *      Make a Character called Bob
             *      Bob Always Misses
             *      Other Characters Always Hit
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for Name of Bob and return miss
             *                 
             * Test Algrorithm:
             *  Create Character named Bob
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with Character of Named Bob
             *  Test with Character of any other name
             * 
             * Validation:
             *      Verify Enum is Miss
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = 200,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                Name = "Bob",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    BaseSpeed = 1,
                    Level = 1,
                    BaseHitPoints = 1,
                    ExperiencePoints = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice rull 19
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(19);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Miss, BattleEngine.BattleMessagesModel.HitStatus);
        }

        [Test]
        public void HackathonScenario_Scenario_2_Character_Not_Bob_Should_Hit()
        {
            /* 
             * Scenario Number:  
             *      2
             *      
             * Description: 
             *      See Default Test
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      See Defualt Test
             *                 
             * Test Algrorithm:
             *      Create Character named Mike
             *      Create Monster
             *      Call TurnAsAttack so Mike can attack Monster
             * 
             * Test Conditions:
             *      Control Dice roll so natural hit
             *      Test with Character of not named Bob
             *  
             *  Validation
             *      Verify Enum is Hit
             *      
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = 200,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                Name = "Mike",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    BaseSpeed = 1,
                    Level = 1,
                    BaseHitPoints = 1,
                    ExperiencePoints = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessagesModel.HitStatus);
        }

        [Test]
        public void HackathonScenario_Scenario_33_Lucky_Round_13_Random_Character_Dies()
        {
            /* 
             * Scenario Number:  
             *      33
             *      
             * Description: 
             *      At the start of round 13 as long as there are 2 chracter alive one of them randmly dies.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Changed the RoundEngine.CS
             *                 
             * Test Algrorithm:
             *     Make two characters
             *     Make a monster
             *     Set round count to 13
             * 
             * Test Conditions:
             *      If round round count is 13 and atleast 2 chracters at still alive one of them dies. 
             *  
             *  Validation
             *      list of characters is 1 after dying. 
             *      
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 2;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = 200,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                Name = "Mike",
                            });
            var CharacterPlayer2 = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = 200,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                Name = "Nick",
                            });

            //BattleEngine.CharacterList.Add(CharacterPlayer);
            //BattleEngine.CharacterList.Add(CharacterPlayer2);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    BaseSpeed = 1,
                    Level = 1,
                    BaseHitPoints = 1,
                    ExperiencePoints = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);
            var OrginalNumberOfCharacter = BattleEngine.CharacterList.Count;

            BattleEngine.BattleScore.RoundCount = 13;
            

            //Act
            BattleEngine.BattleScore.RoundCount = 13;
            BattleEngine.IsRound13();
            var result = BattleEngine.CharacterList.Count;

            //Reset
            

            //Assert
            Assert.AreEqual(OrginalNumberOfCharacter - 1, result);
            
           
        }





        [Test]
        public void HackathonScenario_Scenario_43_Team_Spirit_Item_Description_Equal_Go_SU_Redhawks_Should_Double_Value()
        {
            /* 
             * Scenario Number:  
             *      43
             *      
             * Description: 
             *      Whenever an item with the description "Go SU RedHawks", the item will have 2x
             *      the value of the item.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Changed the TurnEngine.cs
             *                 
             * Test Algrorithm:
             *     Make an Item
             *     Make a Character
             *     Set Item description to "Go SU RedHawks"
             *     Set the Character to equip the item
             * 
             * Test Conditions:
             *      If Item equals "Go SU RedHawks" then it should have 2x the value of the item.
             *  
             *  Validation
             *      Damage taken is increased
             *      
             */

            //Arrange

            // Create Item
            var StrongItem = new ItemModel
                            {
                                Name = "Hackathon 43 Item",
                                Description = "Go SU RedHawks",
                                Range = 10,
                                Value = 20, 
                                Damage = 20
                            };

            BattleEngine.ItemPool.Add(StrongItem);

            // Create Character
            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                BaseSpeed = 5,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                BaseStrength = 10,
                                Name = "Mike",
                                ItemOne = StrongItem.Id
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Create Monster
            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                BaseSpeed = 5,
                                Level = 10,
                                BaseHitPoints = 100,
                                ExperiencePoints = 100,
                                BaseStrength = 10,
                                Name = "Monster Mike"
                            });

            BattleEngine.MonsterList.Add(MonsterPlayer);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer); // damage
            //var result = BattleEngine.CalculateDamage(CharacterPlayer);

            //Reset

            //Assert
            //Assert.AreEqual(0, result);
            Assert.AreEqual(true, result);
        }
    }
}