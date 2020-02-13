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
    public partial class CharacterDeletePage : ContentPage
    {
        GenericViewModel<CharacterModel> ViewModel;

        public CharacterDeletePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();


            BindingContext = this.ViewModel = data;

        }



        /*This function registers the Delete_Clicked event triggered 
        when the user presses the Delete button on the toolbar
        */
        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", ViewModel.Data);
            await Navigation.PopModalAsync();
        }


        /*This function registers the Cancel_Clicked event triggered 
        when the user presses the Cancel button on the toolbar
        */
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}