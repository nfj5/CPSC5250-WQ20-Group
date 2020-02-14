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
    public partial class MonsterIndexPage : ContentPage
    {
        readonly MonsterIndexViewModel ViewModel;

        public MonsterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = MonsterIndexViewModel.Instance;
        }
        //Logic for clicking the add monster button. Adds new monster.
        async void AddMonster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage(new ViewModels.GenericViewModel<Models.MonsterModel>())));
            
        }
        //Logic selecting a monster and seeing its stats from the list view on the monster page.
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            MonsterModel data = args.SelectedItem as MonsterModel;
            if (data == null)
            {
                return;
            }

            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));

            MonsterListView.SelectedItem = null;
        }
        //Refreshes the list view after adding or deleting a monster
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