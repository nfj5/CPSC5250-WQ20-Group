using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterIndexPage : ContentPage
    {
        readonly CharacterIndexViewModel ViewModel;

        public CharacterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = CharacterIndexViewModel.Instance;
            
        }

        async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage(new ViewModels.GenericViewModel<Models.CharacterModel>())));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CharacterModel data = args.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            await Navigation.PushAsync(new CharacterReadPage(new GenericViewModel<CharacterModel>(data)));

            CharactersListView.SelectedItem = null; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            // If no data, then set it for needing refresh
            if (ViewModel.Dataset.Count == 0)
            {
                ViewModel.SetNeedsRefresh(true);
            }

            // If the needs Refresh flag is set update it
            if (ViewModel.NeedsRefresh())
            {
                ViewModel.LoadDatasetCommand.Execute(null);
            }

            BindingContext = ViewModel;
        }


    }
}