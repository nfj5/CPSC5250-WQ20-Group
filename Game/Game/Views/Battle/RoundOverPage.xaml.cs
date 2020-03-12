using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundOverPage: ContentPage
	{
		/// <summary>
		/// Constructor for Round Over Page
		/// </summary>
		public RoundOverPage()
		{
			InitializeComponent ();
		}
		public async void LockerRoom_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LockerRoomPage());
		}


		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void NextButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}