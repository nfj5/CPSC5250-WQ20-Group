using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRoundPage: ContentPage
	{

		/// <summary>
		/// Constructor
		/// </summary>
		public NewRoundPage(int RoundNumber)
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void BeginButton_Clicked(object sender, EventArgs e)
		{
			// TODO pass in information for the battle
			await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
		}

		/// <summary>
		/// Level Up Button Clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void LevelUp_clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new LevelUpPage()));
		}

		/// <summary>
		/// Round Over button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void RoundOver_clicked(object sender, EventArgs e)
		{
			// TODO pass in information for the battle
			await Navigation.PushModalAsync(new NavigationPage(new RoundOverPage()));
		}
	}
}