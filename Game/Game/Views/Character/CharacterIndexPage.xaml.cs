using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterIndexPage : ContentPage
    {
        readonly CharacterIndexViewModel viewModel;

        public CharacterIndexPage()
        {
            InitializeComponent();

            BindingContext = viewModel = CharacterIndexViewModel.Instance;
            
        }

        async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage(new ViewModels.GenericViewModel<Models.CharacterModel>())));
        }

        async void OnCharacterSelected(object sender, Sel)

        
    }
}