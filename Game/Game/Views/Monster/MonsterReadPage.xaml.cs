using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Models;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    public partial class MonsterReadPage : ContentPage
    {
        // View Model for Monster
        public GenericViewModel<MonsterModel> ViewModel { get; set; }

        // Empty Constructor for UTs
        public MonsterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for MonsterReadPage
        /// 
        /// The ViewModel is the data that should be displayed
        /// </summary>
        /// <param name="data"></param>
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            this.ViewModel.Title = "Read";
        }


        /// <summary>
        /// Navigate to page to Edit the Monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Navigate to page to Delete the Monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }
    }
}
