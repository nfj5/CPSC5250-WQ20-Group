using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class PersonJobEnumExtensionsTests
    {
        [Test]
        public void PersonJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = PersonJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void PersonJobEnumExtensionsTests_QB_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = PersonJobEnum.QB.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Quarter back", result);
        }

        [Test]
        public void PersonJobEnumExtensionsTests_RB_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = PersonJobEnum.RB.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Running back", result);
        }

        [Test]
        public void PersonJobEnumExtensionsTests_WR_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = PersonJobEnum.WR.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Wide Receiver", result);
        }
    }
}
