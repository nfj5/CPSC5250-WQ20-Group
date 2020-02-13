using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Models;
using Xamarin.Forms;

namespace Game.Views.Monster
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
    }
}
