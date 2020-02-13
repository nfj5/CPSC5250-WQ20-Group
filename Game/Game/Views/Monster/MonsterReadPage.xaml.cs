using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Models;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class MonsterReadPage : ContentPage
    {
        GenericViewModel<MonsterModel> ViewModel { get; set; }

        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            this.ViewModel.Title = "Read";
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }
    }
}
