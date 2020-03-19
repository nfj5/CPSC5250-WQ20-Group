using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class AbilityEnumExtensionsTests
    {
        [Test]
        public void AbilityEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_SpeedAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.SpeedAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Speed boost", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_StrengthAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.StrengthAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Strength boost", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_ThiccnessAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.ThiccnessAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Stamina boost", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_StaminaAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.StaminaAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Stamina boost", result);
        }

    }
}
