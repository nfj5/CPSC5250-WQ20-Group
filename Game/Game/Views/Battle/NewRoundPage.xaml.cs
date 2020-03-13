using Game.ViewModels;
using Game.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRoundPage: ContentPage
	{
		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public NewRoundPage(int RoundNumber)
		{
			InitializeComponent ();

			// Read in the Characters that are still alive, show their images in the list
			foreach (PlayerInfoModel character in EngineViewModel.Engine.CharacterList)
			{
				var image = new Image { Source = character.ImageURI, Style = (Xamarin.Forms.Style) App.Current.Resources["ImageMediumStyle"] };
				CharactersList.Children.Add(image);
			}

			// Create some monsters for this round, show them in the list
			for (int i = 0; i < EngineViewModel.Engine.CharacterList.Count; ++i)
			{
				// TODO Generate monsters based upon round number
				PlayerInfoModel newMonster = new PlayerInfoModel(new MonsterModel());

				var image = new Image { Source = newMonster.ImageURI, Style = (Xamarin.Forms.Style)App.Current.Resources["ImageMediumStyle"] };
				MonstersList.Children.Add(image);

				EngineViewModel.Engine.MonsterList.Add(newMonster);
			}

			Debug.WriteLine("Generated " + EngineViewModel.Engine.MonsterList.Count + " monsters.");
		}

		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void BeginButton_Clicked(object sender, EventArgs e)
		{
			// TODO pass in information for the battle
			await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
		}

		/// <summary>
		/// Level Up Button Clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void LevelUp_clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new LevelUpPage()));
		}

		/// <summary>
		/// Round Over button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void RoundOver_clicked(object sender, EventArgs e)
		{
			// TODO pass in information for the battle
			await Navigation.PushModalAsync(new NavigationPage(new RoundOverPage()));
		}
	}
}