using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattleNavigation : ContentPage
    {
        public BattleNavigation()
        {
            InitializeComponent();
        }

        // Open the PickCharacters page when CharacterPicker button clicked
        public async void CharacterPicker_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        // Open the ScorePage when GameEnd button clicked
        public async void GameEnd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage());
        }

        // Open the PickCharacters page when CharacterPicker button clicked
        public async void BattlePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }

        // Open the PickCharacters page when CharacterPicker button clicked
        public async void PersonDie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PersonDiePage(new GenericViewModel<CharacterModel>())));
        }
        // Open the PickCharacters page when CharacterPicker button clicked
        public async void RoundOver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoundOverPage());
        }
        public async void LevelUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LevelUpPage());
        }
    }
}