using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
    public class CharacterModelTests
    {
        [TearDown]
        public void TearDown()
        {
            // For Tear down delete the Item Dataset.
            // Test that need the Item Dataset should set it
            ItemIndexViewModel.Instance.Dataset.Clear();
        }

        [Test]
        public void CharacterModel_Constructor_Default_Should_Pass()
        {
            // ArDefense

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        //[Test]
        //public void CharacterModel_Constructor_New_Item_Should_Copy()
        //{
        //    // ArDefense
        //    var dataNew = new CharacterModel();
        //    dataNew.Attack = 2;
        //    dataNew.Id = "oldID";

        //    // Act
        //    var result = new CharacterModel(dataNew);

        //    // Reset

        //    // Assert 
        //    Assert.AreNotEqual("oldID", result.Id);
        //}

        [Test]
        public void CharacterModel_Get_Default_Should_Pass()
        {
            // ArDefense

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.BaseStrength);
            Assert.IsNotNull(result.BaseThiccness);
            Assert.IsNotNull(result.BaseSpeed);
        }

        [Test]
        public void CharacterModel_Set_Default_Should_Pass()
        {
            // ArDefense

            // Act
            var result = new CharacterModel();
            result.BaseStrength = 6;
            result.BaseThiccness = 7;
            result.BaseSpeed = 8;

            // Reset

            // Assert 
            Assert.AreEqual(6, result.BaseStrength);
            Assert.AreEqual(7, result.BaseThiccness);
            Assert.AreEqual(8, result.BaseSpeed);

            Assert.IsNotNull(result.Id);
            Assert.AreEqual(result.Id, result.Guid);

            Assert.AreEqual("knight.png", result.ImageURI);
            Assert.AreEqual(PersonTypeEnum.Character, result.PersonType);

            Assert.AreEqual(true, result.Alive);
            Assert.AreEqual(0, result.ListOrder);
            Assert.AreEqual(1, result.Level);
            Assert.AreEqual(0, result.CurrentHitPoints);
            Assert.AreEqual(0, result.BaseHitPoints);
            Assert.AreEqual(0, result.ExperiencePoints);

            Assert.AreEqual(null, result.Head);
            Assert.AreEqual(null, result.Feet);
            Assert.AreEqual(null, result.Necklass);
            Assert.AreEqual(null, result.PrimaryHand);
            Assert.AreEqual(null, result.OffHand);
            Assert.AreEqual(null, result.Finger);

        }

        //[Test]
        //public void CharacterModel_Update_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var dataOriginal = new CharacterModel();
        //    dataOriginal.BaseStrength = 1;

        //    var dataNew = new CharacterModel();
        //    dataNew.BaseStrength = 2;

        //    // Act
        //    var result = dataOriginal.Update(dataNew);

        //    // Reset

        //    // Assert 
        //    Assert.AreEqual(true, result);
        //    Assert.AreEqual(2, dataOriginal.Attack);
        //}

        //[Test]
        //public void CharacterModel_Update_InValid_Null_Should_Fail()
        //{
        //    // ArDefense
        //    var dataOriginal = new CharacterModel();
        //    dataOriginal.BaseStrength = 2;

        //    // Act
        //    var result = dataOriginal.Update(null);

        //    // Reset

        //    // Assert 
        //    Assert.AreEqual(false, result);
        //    Assert.AreEqual(2, dataOriginal.Attack);
        //}

        [Test]
        public void CharacterModel_FormatOuput_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert 
            Assert.AreEqual(true, result.Contains("Bob Jones"));
        }

        [Test]
        public void CharacterModel_Set_Get_Default_Should_Pass()
        {
            // ArDefense
            var result = new CharacterModel();

            // Act
            result.Id = "bogus";
            result.ImageURI = "uri";
            result.PersonType = PersonTypeEnum.Monster;
            result.Alive = false;
            result.Guid = "guid";
            result.ListOrder = 200;
            result.BaseSpeed = 300;
            result.Level = 400;
            result.ExperiencePoints = 500;
            result.CurrentHitPoints = 600;
            result.BaseHitPoints = 700;
            result.BaseThiccness = 900;
            result.BaseStrength = 123;
            result.Head = "head";
            result.Feet = "feet";
            result.Necklass = "necklass";
            result.PrimaryHand = "primaryhand";
            result.OffHand = "offhand";
            result.Finger = "Finger";

            // Reset

            // Assert
            Assert.AreEqual("bogus", result.Id);
            Assert.AreEqual("uri", result.ImageURI);
            Assert.AreEqual(PersonTypeEnum.Monster, result.PersonType);
            Assert.AreEqual(false, result.Alive);
            Assert.AreEqual("guid", result.Guid);
            Assert.AreEqual(200, result.ListOrder);
            Assert.AreEqual(300, result.BaseSpeed);
            Assert.AreEqual(400, result.Level);
            Assert.AreEqual(500, result.ExperiencePoints);
            Assert.AreEqual(600, result.CurrentHitPoints);
            Assert.AreEqual(700, result.BaseHitPoints);
            Assert.AreEqual(900, result.BaseThiccness);
            Assert.AreEqual(123, result.BaseStrength);
            Assert.AreEqual("head", result.Head);
            Assert.AreEqual("feet", result.Feet);
            Assert.AreEqual("necklass", result.Necklass);
            Assert.AreEqual("primaryhand", result.PrimaryHand);
            Assert.AreEqual("offhand", result.OffHand);
            Assert.AreEqual("Finger", result.Finger);
        }


        //[Test]
        //public void CharacterModel_GetAttack_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var data = new CharacterModel();

        //    // Act
        //    var result = data.GetAttack();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(1, result);
        //}

        //[Test]
        //public void CharacterModel_GetDefense_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var data = new CharacterModel();

        //    // Act
        //    var result = data.GetDefense();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(1, result);
        //}

        //[Test]
        //public void CharacterModel_GetSpeed_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var data = new CharacterModel();

        //    // Act
        //    var result = data.GetSpeed();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(1, result);
        //}

        //[Test]
        //public void CharacterModel_GetHealthCurrent_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var data = new CharacterModel();

        //    // Act
        //    var result = data.GetCurrentHealthTotal;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(0, result);
        //}

        //[Test]
        //public void CharacterModel_GetHealthMax_Default_Should_Pass()
        //{
        //    // ArDefense
        //    var data = new CharacterModel();

        //    // Act
        //    var result = data.GetMaxHealthTotal;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(0, result);
        //}

        [Test]
        public void CharacterModel_CauseDeath_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.CauseDeath();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CharacterModel_FormatOutput_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("Bob Jones"));
        }


        [Test]
        public void CharacterModel_GetItemByLocation_Head_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_Feet_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_Necklass_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Necklass);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_PrimaryHand_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_OffHand_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.OffHand);

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_RightFinger_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_LeftFinger_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void CharacterModel_GetItemByLocation_Unknown_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task CharacterModel_DropAllItems_Default_Should_Pass()
        {
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            var item = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();

            // ArDefense
            var data = new CharacterModel
            {
                Head = item.Id,
                Necklass = item.Id,
                PrimaryHand = item.Id,
                OffHand = item.Id,
                Finger = item.Id,
                Feet = item.Id,
            };

            // Act
            var result = data.DropAllItems();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterModel_AddItem_Unknown_Should_Fail()
        {
            // ArDefense
            var data = new CharacterModel();

            // Act
            var result = data.AddItem(ItemLocationEnum.Unknown, "bogus");

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task CharacterModel_AddItem_Default_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            var itemOld = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();

            // Act

            // Add the second item, this will return the first item as the one replaced which is null
            var result = data.AddItem(ItemLocationEnum.Head, itemOld.Id);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task CharacterModel_AddItem_Default_Replace_Should_Pass()
        {
            // ArDefense
            var data = new CharacterModel();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            var itemOld = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();
            var itemNew = ItemIndexViewModel.Instance.Dataset.LastOrDefault();

            // Add the first item
            data.AddItem(ItemLocationEnum.Head, itemOld.Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.AddItem(ItemLocationEnum.Head, itemNew.Id);

            // Reset

            // Assert
            Assert.AreEqual(itemOld.Id, result.Id);
        }


        //[Test]
        //public async Task CharacterModel_GetItemBonus_Default_Attack_Should_Pass()
        //{
        //    // ArDefense

        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id="head" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });

        //    var data = new CharacterModel();

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.Head, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
        //    data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
        //    data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
        //    data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
        //    data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
        //    data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetItemBonus(AttributeEnum.Attack);

        //    // Reset
            

        //    // Assert
        //    Assert.AreEqual(7654321, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetAttackTotal_Default_Attack_Should_Pass()
        //{
        //    // ArDefense

        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });

        //    var data = new CharacterModel();

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.Head, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
        //    data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
        //    data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
        //    data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
        //    data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
        //    data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetAttackTotal;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(7654322, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDefenseTotal_Default_Defense_Should_Pass()
        //{
        //    // ArDefense
          
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 1, Id = "head" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 20, Id = "necklass" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 300, Id = "PrimaryHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 4000, Id = "OffHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 50000, Id = "RightFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 600000, Id = "LeftFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 7000000, Id = "feet" });

        //    var data = new CharacterModel();

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.Head, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
        //    data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
        //    data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
        //    data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
        //    data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
        //    data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetDefenseTotal;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(7654322, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDamageTotal_Default_Speed_Should_Pass()
        //{
        //    // ArDefense
            
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 1, Id = "head" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 20, Id = "necklass" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 300, Id = "PrimaryHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 4000, Id = "OffHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 50000, Id = "RightFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 600000, Id = "LeftFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 7000000, Id = "feet" });

        //    var data = new CharacterModel();

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.Head, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
        //    data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
        //    data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
        //    data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
        //    data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
        //    data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetSpeedTotal;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(7654322, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDamageRollAttack_Default_Speed_Should_Pass()
        //{
        //    // ArDefense
            
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });

        //    var data = new CharacterModel();
        //    data.Level = 1;

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.Head, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
        //    data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
        //    data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
        //    data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
        //    data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
        //    data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

        //    Game.Helpers.DiceHelper.EnableForcedRolls();
        //    Game.Helpers.DiceHelper.SetForcedRollValue(1);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetDamageRollValue();

        //    // Reset
        //    Game.Helpers.DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(2, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDamageItemBonus_Default_Speed_Should_Pass()
        //{
        //    // ArDefense
           
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" , Damage=1});

        //    var data = new CharacterModel();
        //    data.Level = 1;

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

        //    Game.Helpers.DiceHelper.EnableForcedRolls();
        //    Game.Helpers.DiceHelper.SetForcedRollValue(1);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetDamageItemBonus;

        //    // Reset
        //    Game.Helpers.DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(1, result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDamageItemBonusString_Default_Speed_Should_Pass()
        //{
        //    // ArDefense
            
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand", Damage = 1 });

        //    var data = new CharacterModel();
        //    data.Level = 1;

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

        //    Game.Helpers.DiceHelper.EnableForcedRolls();
        //    Game.Helpers.DiceHelper.SetForcedRollValue(1);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetDamageItemBonusString;

        //    // Reset
        //    Game.Helpers.DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual("1D 1", result);
        //}

        //[Test]
        //public async Task CharacterModel_GetDamageTotalString_Default_Speed_Should_Pass()
        //{
        //    // ArDefense
            
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand", Damage = 1 });

        //    var data = new CharacterModel();
        //    data.Level = 1;

        //    // Add the first item
        //    data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

        //    Game.Helpers.DiceHelper.EnableForcedRolls();
        //    Game.Helpers.DiceHelper.SetForcedRollValue(1);

        //    // Act

        //    // Add the second item, this will return the first item as the one replaced
        //    var result = data.GetDamageTotalString;

        //    // Reset
        //    Game.Helpers.DiceHelper.DisableForcedRolls();
 
        //    // Assert
        //    Assert.AreEqual("1 + 1D 1", result);
        //}
    }
}