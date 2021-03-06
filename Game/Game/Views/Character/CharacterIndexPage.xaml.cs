﻿using System;
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
    /// <summary>
    /// Index Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterIndexPage : ContentPage
    {
        // The Character Index view model
        readonly CharacterIndexViewModel ViewModel;

        // Empty Constructor for UTs
        public CharacterIndexPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for character index page
        /// 
        /// Gets the current CharacterIndexViewModel
        /// </summary>
        public CharacterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = CharacterIndexViewModel.Instance;
            
        }

        /// <summary>
        /// Add a new Character 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage(new ViewModels.GenericViewModel<Models.CharacterModel>())));
        }

        /// <summary>
        /// Read a selected Character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CharacterModel data = args.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            await Navigation.PushAsync(new CharacterReadPage(new GenericViewModel<CharacterModel>(data)));

            CharactersListView.SelectedItem = null; 
        }

        /// <summary>
        /// Refreshes the list view after adding or deleting a Character
        /// </summary>
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