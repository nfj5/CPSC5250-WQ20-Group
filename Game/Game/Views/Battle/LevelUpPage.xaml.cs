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
    public partial class LevelUpPage : ContentPage
    {

        // To be changed when Battle Logic is implemented
        //GenericViewModel<CharacterModel> ViewModel;

        /// <summary>
        /// Constructor for LevelUpPage
        /// </summary>
        public LevelUpPage()//GenericViewModel<CharacterModel> data) 
        {
            InitializeComponent();

            //BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Returns the user back to the Battle page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void KeepBrawling_clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}