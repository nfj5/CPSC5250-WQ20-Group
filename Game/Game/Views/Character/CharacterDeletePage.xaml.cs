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
    /// The Delete Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDeletePage : ContentPage
    {
        // View Model for Character
        GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CharacterDeletePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Delete by taking a view model of character to delete
        /// </summary>
        /// <param name="data"></param>
        public CharacterDeletePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();


            BindingContext = this.ViewModel = data;

        }

        /// <summary>
        /// Deletes the indexed Character.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}