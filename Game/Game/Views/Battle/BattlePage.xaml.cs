﻿using Game.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Engine;
using Game.Models;
using Game.ViewModels;
using System.Diagnostics;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage: ContentPage
	{
		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public BattlePage ()
		{
			InitializeComponent ();

			int left = 0;
			foreach (PlayerInfoModel character in EngineViewModel.Engine.CharacterList)
			{
				GameBoardModel.PlayerLocations[left, 0] = character;
				left++;
			}

			left = 0;
			foreach (PlayerInfoModel monster in EngineViewModel.Engine.MonsterList)
			{
				GameBoardModel.PlayerLocations[left, GameBoardModel.Size - 1] = monster;
				left++;
			}

			RefreshGameBoard();
		}

		// Wipe the gameboard
		public void WipeGameBoard()
		{
			GameBoardGrid.Children.Clear();
		}

		// Update the game board
		public void RefreshGameBoard()
		{
			WipeGameBoard();

			for (int x = 0; x < GameBoardModel.Size; ++x)
			{
				for (int y = 0; y < GameBoardModel.Size; ++y)
				{
					string source = "blank_space.png";
					PlayerInfoModel player = GameBoardModel.GetPlayer(x, y);

					if (player != null)
					{
						source = player.ImageURI;
					}

					ImageButton currentButton = new ImageButton { Source = source };
					Grid.SetRow(currentButton, x);
					Grid.SetColumn(currentButton, y);

					currentButton.Clicked += (sender, e) => LocationClicked(sender, e);
					GameBoardGrid.Children.Add(currentButton);
				}
			}
		}

		/// <summary>
		/// Attack Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AttackButton_Clicked(object sender, EventArgs e)
		{
			DisplayAlert("SU", "Attack !!!", "OK");
		}

		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void RoundOverButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RoundOverPage());
		}


		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void NewRoundButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewRoundPage(GameBoardHelper.Round));
		}


		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void BattleOverButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new ScorePage());
		}

		/// <summary>
		/// Battle Over, so Exit Button
		/// Need to show this for the user to click on.
		/// The Quit does a prompt, exit just exits
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ExitButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		/// <summary>
		/// Quit the Battle
		/// 
		/// Quitting out
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void QuitButton_Clicked(object sender, EventArgs e)
		{
			bool answer = await DisplayAlert("Battle", "Are you sure you want to Quit?", "Yes", "No");

			if (answer)
			{
				await Navigation.PopModalAsync();
			}
		}

		public void LocationClicked(object sender, EventArgs e)
        {
			ImageButton clicked = (ImageButton) sender;
			int row = Grid.GetRow(clicked);
			int column = Grid.GetColumn(clicked);

            //Checks if the row column that was clicked has a Character type person.
            if (GameBoardModel.isPlayer(row, column))
            {
                //Assigns character type person to player to pass to UpdateInventory
				PlayerInfoModel player = GameBoardModel.GetPlayer(row, column);
				if (player != null)
				{
					// Unselect if we are currently selected
					if (GameBoardHelper.SelectedCharacter == player.Id)
					{
						GameBoardHelper.SelectedCharacter = null;
						BattleLog.Text += "\nDeselected " + player.Name;
						WipeInventory();
						return;
					}

					// Select the player
					if (GameBoardHelper.SelectedCharacter == null)
					{
						GameBoardHelper.SelectedCharacter = player.Id;
						BattleLog.Text += "\nSelected " + player.Name;
						UpdateInventory(player);
					}
				}
            }

			Debug.WriteLine("Clicked " + row + "," + column);
		}

		/// <summary>
		/// Update the inventory display with Character's items
		/// </summary>
		/// <param name="player"></param>
		public void UpdateInventory(PlayerInfoModel player)
        {
            //Checks if player has a head item. If so assigns it to inventory.
			if (player.Head != null)
				InventoryHead.Source = ItemIndexViewModel.Instance.GetItem(player.Head).ImageURI;

            //Checks if player has necklass item. If so assigns it to inventory. 
			if (player.Necklass != null)
				InventoryNecklass.Source = ItemIndexViewModel.Instance.GetItem(player.Necklass).ImageURI;

			//Checks if player has PrimaryHand item. If so assigns it to inventory.
			if (player.PrimaryHand != null)
				InventoryPrimaryHand.Source = ItemIndexViewModel.Instance.GetItem(player.PrimaryHand).ImageURI;

			//Checks if player has offHand item. If so assigns it to inventory.
			if (player.OffHand != null)
				InventoryOffHand.Source = ItemIndexViewModel.Instance.GetItem(player.OffHand).ImageURI;

			//Checks if player has Feet item. If so assigns it to inventory.
			if (player.Feet != null)
				InventoryFeet.Source = ItemIndexViewModel.Instance.GetItem(player.Feet).ImageURI;

			//Cehcks if palyer has Finger item. If so assigns it to inventory.
			if (player.Finger != null)
				InventoryFinger.Source = ItemIndexViewModel.Instance.GetItem(player.Finger).ImageURI;

			// Update the label
			InventoryLabel.Text = player.Name + "'s Inventory";
		}

		/// <summary>
		/// Wipe the inventory display
		/// </summary>
		public void WipeInventory()
		{
			InventoryHead.Source = "icon_add.png";
			InventoryNecklass.Source = "icon_add.png";
			InventoryPrimaryHand.Source = "icon_add.png";
			InventoryOffHand.Source = "icon_add.png";
			InventoryFeet.Source = "icon_add.png";
			InventoryFinger.Source = "icon_add.png";

			// Update the label
			InventoryLabel.Text = "Inventory";
		}

	}
}