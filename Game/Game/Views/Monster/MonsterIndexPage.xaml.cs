using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Views.Monster;
using Xamarin.Forms;

namespace Game.Views
{
    public partial class MonsterIndexPage : ContentPage
    {
        readonly MonsterIndexViewModel ViewModel;

        public MonsterIndexPage()
        {
            //InitializeComponent();

            //BindingContext = ViewModel = MonsterIndexViewModel.Instance;
        }

        async void AddMonster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage(new ViewModels.GenericViewModel<Models.MonsterModel>())));
            
        }

    }
}