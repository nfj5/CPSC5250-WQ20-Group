﻿using System.ComponentModel;
using Xamarin.Forms;
using Game.ViewModels;
using System;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemReadPage : ContentPage
    {
        // View Model for Item
        readonly GenericViewModel<ItemModel> ViewModel;
        
        // Empty Constructor for UTs
        public ItemReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public ItemReadPage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Navigate to page to Edit the Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(new GenericViewModel<ItemModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Navigate to page to Delete the Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(new GenericViewModel<ItemModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }
    }
}