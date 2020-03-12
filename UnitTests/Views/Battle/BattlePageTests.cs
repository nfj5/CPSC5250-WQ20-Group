﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class BattlePageTests
    {
        App app;
        BattlePage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new BattlePage();

            // Put seed data into the system for all tests
            page.EngineViewModel.Engine.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));
            page.EngineViewModel.Engine.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));
            page.EngineViewModel.Engine.MakePlayerList();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattlePage_AttackButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.AttackButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ShowScoreButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowScoreButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ExitButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ExitButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_StartButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.StartButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextRoundButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.NextRoundButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ShowModalRoundOverPage_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowModalRoundOverPage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void BattlePage_ClearMessages_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClearMessages();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_GameMessage_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.GameMessage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_GameMessage_LevelUp_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.BattleMessagesModel.LevelUpMessage = "me";

            // Act
            page.GameMessage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        [Test]
        public void BattlePage_DrawGameBoardAttackerDefender_CurrentAttacker_Null_CurrentDefender_Null_Should_Pass()
        {
            // Arrange
            page.EngineViewModel.Engine.CurrentAttacker = null;
            page.EngineViewModel.Engine.CurrentDefender = null;

            // Act
            page.DrawGameAttackerDefenderBoard();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_DrawGameBoardAttackerDefender_CurrentAttacker_InValid_Null_Should_Pass()
        {
            // Arrange

            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            page.EngineViewModel.Engine.CurrentAttacker = PlayerInfo;
            page.EngineViewModel.Engine.CurrentDefender = null;

            // Act
            page.DrawGameAttackerDefenderBoard();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_DrawGameBoardAttackerDefender_CurrentDefender_InValid_Null_Should_Pass()
        {
            // Arrange

            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            page.EngineViewModel.Engine.CurrentAttacker = null;
            page.EngineViewModel.Engine.CurrentDefender = PlayerInfo;

            // Act
            page.DrawGameAttackerDefenderBoard();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_DrawGameBoardAttackerDefender_CurrentDefender_Valid_Should_Pass()
        {
            // Arrange

            page.EngineViewModel.Engine.CurrentAttacker = new PlayerInfoModel(new CharacterModel());
            page.EngineViewModel.Engine.CurrentDefender = new PlayerInfoModel(new CharacterModel { Alive=false });

            // Act
            page.DrawGameAttackerDefenderBoard();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextAttackExample_NextRound_Should_Pass()
        {
            // Arrange

            page.EngineViewModel.Engine.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            page.EngineViewModel.Engine.MonsterList.Clear();

            page.EngineViewModel.Engine.MakePlayerList();

            // Has no monster, so should show next round.

            // Act
            page.NextAttackExample();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextAttackExample_GameOver_Should_Pass()
        {
            // Arrange

            page.EngineViewModel.Engine.CharacterList.Clear();
            page.EngineViewModel.Engine.MonsterList.Clear();
            page.EngineViewModel.Engine.PlayerList.Clear();

            page.EngineViewModel.Engine.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            page.EngineViewModel.Engine.MakePlayerList();

            // Has no Character, so should show end game

            // Act
            page.NextAttackExample();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Character_vs_Monster_Should_Pass()
        {
            // Arrange
            page.EngineViewModel.Engine.CharacterList.Clear();
            page.EngineViewModel.Engine.MonsterList.Clear();
            page.EngineViewModel.Engine.PlayerList.Clear();

            // Make Character
            page.EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            page.EngineViewModel.Engine.CharacterList.Add(CharacterPlayer);

            // Make Monster

            page.EngineViewModel.Engine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            page.EngineViewModel.Engine.PlayerList.Add(CharacterPlayer);
            page.EngineViewModel.Engine.PlayerList.Add(MonsterPlayer);

            page.EngineViewModel.Engine.CurrentAttacker = MonsterPlayer;

            page.EngineViewModel.Engine.CurrentAttacker = null;

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Monster_vs_Character_Should_Pass()
        {
            // Arrange

            page.EngineViewModel.Engine.CharacterList.Clear();
            page.EngineViewModel.Engine.MonsterList.Clear();
            page.EngineViewModel.Engine.PlayerList.Clear();

            // Make Character
            page.EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            page.EngineViewModel.Engine.CharacterList.Add(CharacterPlayer);

            // Make Monster

            page.EngineViewModel.Engine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            page.EngineViewModel.Engine.MonsterList.Add(MonsterPlayer);

            page.EngineViewModel.Engine.PlayerList.Add(CharacterPlayer);
            page.EngineViewModel.Engine.PlayerList.Add(MonsterPlayer);

            page.EngineViewModel.Engine.CurrentAttacker = CharacterPlayer;

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Character_vs_Unknown_Should_Pass()
        {
            // Arrange
            page.EngineViewModel.Engine.CharacterList.Clear();
            page.EngineViewModel.Engine.MonsterList.Clear();
            page.EngineViewModel.Engine.PlayerList.Clear();

            // Make Character
            page.EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            page.EngineViewModel.Engine.CharacterList.Add(CharacterPlayer);

            // Make Monster

            page.EngineViewModel.Engine.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                PlayerType = PlayerTypeEnum.Unknown
                            });

            page.EngineViewModel.Engine.MonsterList.Add(MonsterPlayer);

            page.EngineViewModel.Engine.PlayerList.Add(CharacterPlayer);
            page.EngineViewModel.Engine.PlayerList.Add(MonsterPlayer);

            page.EngineViewModel.Engine.CurrentAttacker = CharacterPlayer;

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_GameOver_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.GameOver();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedCharacter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedCharacter(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedMonster_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedMonster(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedEmpty_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedEmpty(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true,result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_Image_Should_Fail()
        {
            // Make the Row Bogus
            page.EngineViewModel.Engine.MapModel.MapGridLocation[0, 0].Row = -1;

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            page.EngineViewModel.Engine.MapModel.MapGridLocation[0, 0].Row = 0;

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_ImageButton_Should_Fail()
        {
            // Get the current valute
            var name = "MapR0C0ImageButton";
            page.MapLocationObject.TryGetValue(name, out object data);
            page.MapLocationObject.Remove(name);

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            page.MapLocationObject.Add(name, data);

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_Stack_Should_Fail()
        {
            // Get the current valute
            var nameStack = "MapR0C0Stack";
            page.MapLocationObject.TryGetValue(nameStack, out object dataStack);
            page.MapLocationObject.Remove(nameStack);

            var nameImage= "MapR0C0ImageButton";
            page.MapLocationObject.TryGetValue(nameImage, out object dataImage);
            page.MapLocationObject.Remove(nameImage);

            var dataImageBogus = new ImageButton { AutomationId = "bogus" };
            page.MapLocationObject.Add(nameImage, dataImageBogus);

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            page.MapLocationObject.Remove(nameImage);
            page.MapLocationObject.Add(nameImage, dataImage);
            page.MapLocationObject.Add(nameStack, dataStack);

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        //[Test]
        //public void BattlePage_MapGridObjectAddImage_Valid_Should_Pass()
        //{
        //    var PlayerImageButton = DetermineMapImageButton(MapModel);

        //    var PlayerStack = new StackLayout
        //    {
        //        Padding = 0,
        //        Style = (Style)Application.Current.Resources["BattleMapImageBox"],
        //        HorizontalOptions = LayoutOptions.Center,
        //        VerticalOptions = LayoutOptions.Center,
        //        BackgroundColor = DetermineMapBackgroundColor(MapModel),
        //        Children = {
        //            PlayerImageButton
        //        },
        //    };

        //    MapGridObjectAddImage(PlayerImageButton, MapModel);
        //    // Act
        //    var result = page.MapGridObjectAddImage(ImageButton data, MapModelLocation MapModel));

        //    // Reset
        //    page.MapLocationObject.Remove(nameImage);
        //    page.MapLocationObject.Add(nameImage, dataImage);
        //    page.MapLocationObject.Add(nameStack, dataStack);

        //    // Assert
        //    Assert.AreEqual(false, result); // Got to here, so it happened...
        //}
    }
}