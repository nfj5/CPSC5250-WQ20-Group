using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage: ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ScorePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Attack Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void NewGame_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BattlePage());
		}

		async void HighScore_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ScoreIndexPage());
		}

		async void MainMenu_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

        // Todo get real score and display. 
	}
}