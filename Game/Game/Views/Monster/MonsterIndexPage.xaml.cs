using System;
using System.Collections.Generic;
using Game.ViewModels;
using Xamarin.Forms;

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

    }
}