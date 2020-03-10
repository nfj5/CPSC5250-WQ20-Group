using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class PlayerInfoModelTests
    {
        [Test]
        public void PlayerInfoModel_Constructor_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            
            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Monster_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Fighter_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Fighter};

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Cleric_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Cleric};

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Unknown_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Unknown };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}