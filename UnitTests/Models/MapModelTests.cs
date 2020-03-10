using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTests.Models
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
    [TestFixture]
    public class MapModelTests
    {
        [Test]
        public void MapModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void MapModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.EmptySquare);
            Assert.IsNotNull(result.MapGridLocation);
        }

        [Test]
        public void MapModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();
            result.EmptySquare = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Unknown };
            result.MapXAxiesCount = 1;
            result.MapYAxiesCount = 1;
            result.MapGridLocation = new MapModelLocation[result.MapXAxiesCount, result.MapYAxiesCount];

            // Reset

            // Assert 
            Assert.IsNotNull(result.EmptySquare);
            Assert.IsNotNull(result.MapGridLocation);
        }

        [Test]
        public void MapModel_ClearSelection_Should_Pass()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 1;
            map.MapYAxiesCount = 1;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];


            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ClearSelection();

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_ClearMapGrid_Should_Pass()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 1;
            map.MapYAxiesCount = 1;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];


            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ClearMapGrid();

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToX_Neg_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData,-1,0);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToY_Neg_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, 0, -1);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToX_Over_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, 100, 0);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToY_Over_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, 0, 100);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_Valid_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, 1, 1);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }
    }
}