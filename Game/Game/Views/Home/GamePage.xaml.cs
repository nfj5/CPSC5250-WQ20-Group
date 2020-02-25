﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Engine;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GamePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        async void StadiumButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the Village
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void LockerRoomButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LockerRoomPage());
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Run the Autobattle simulation from here
			AutoBattleEngine engine = new AutoBattleEngine();
			await engine.RunAutoBattle();

			// Call to the Score Page
			await Navigation.PushModalAsync(new NavigationPage(new ScorePage()));
		}
	}
}