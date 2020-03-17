using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    [TestFixture]
    class AbilityEnumHelperTests
    {
        [Test]
        public void AbilityEnumHelper_GetListItem_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListItem;

            // Assert
            Assert.AreEqual(10,result.Count());

            // Assert
        }

        [Test]
        public void AbilityEnumHelper_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListCharacter;

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();

            AbilityEnum myActual;
            AbilityEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = AbilityEnumHelper.ConvertStringToEnum(item);
                myExpected = (AbilityEnum)Enum.Parse(typeof(AbilityEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void AbilityEnumHelper_GetLocationByPosition_Speed_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetLocationByPosition(1);

            // Assert
            Assert.AreEqual(AbilityEnum.SpeedAbility, result);
        }

        [Test]
        public void AbilityEnumHelper_GetLocationByPosition_Strength_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetLocationByPosition(2);

            // Assert
            Assert.AreEqual(AbilityEnum.StrengthAbility, result);
        }

        [Test]
        public void AbilityEnumHelper_GetLocationByPosition_Thiccness_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetLocationByPosition(3);

            // Assert
            Assert.AreEqual(AbilityEnum.ThiccnessAbility, result);
        }

        [Test]
        public void AbilityEnumHelper_GetLocationByPosition_Stamina_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetLocationByPosition(4);

            // Assert
            Assert.AreEqual(AbilityEnum.StaminaAbility, result);
        }
    }
}

