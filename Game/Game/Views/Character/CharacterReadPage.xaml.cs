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
    /// <summary>
    /// The Read Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for Character
        GenericViewModel<CharacterModel> ViewModel { get; set; }

        // Empty Constructor for UTs
        public CharacterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for CharacterReadPage
        /// 
        /// The ViewModel is the data that should be displayed
        /// </summary>
        /// <param name="data"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            this.ViewModel.Title = "Read";
        }

        /// <summary>
        /// Navigate to page to Edit the Character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Navigate to page to Delete the Character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }
    }
}