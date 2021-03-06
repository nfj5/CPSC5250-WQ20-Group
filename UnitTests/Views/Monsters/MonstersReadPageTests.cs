﻿using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterReadPageTests : MonsterReadPage
    {
        App app;
        MonsterReadPage page;

        public MonsterReadPageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterReadPage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void MonsterReadPage_GetItemToDisplay_Valid_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.GetItemToDisplay();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterReadPage_ShowPopup_Valid_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ShowPopup(new ItemModel());

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterReadPage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterReadPage_AddItemsToDisplay_With_Data_Should_Remove_And_Pass()
        //{
        //    // Arrange

        //    // Put some data into the box so it can be removed
        //    FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

        //    itemBox.Children.Add(new Label());
        //    itemBox.Children.Add(new Label());

        //    // Act
        //    page.AddItemsToDisplay();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(1, itemBox.Children.Count()); // Got to here, so it happened...
        //}

        //[Test]
        //public async Task MonsterReadPage_GetItemToDisplay_With_Item_Should_Pass()
        //{
        //    // Arrange
        //    ItemIndexViewModel.Instance.Dataset.Clear();

        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

        //    var Monster = new MonsterModel();
        //    Monster.Head = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First().Id;
        //    page.ViewModel.Data = Monster;

        //    // Act
        //    var result = page.GetItemToDisplay();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        //}

        //[Test]
        //public async Task MonsterReadPage_GetItemToDisplay_With_NoItem_Should_Pass()
        //{
        //    // Arrange
        //    ItemIndexViewModel.Instance.Dataset.Clear();
        //    await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

        //    // Act
        //    var result = page.GetItemToDisplay();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        //}
    }
}