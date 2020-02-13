using System;
using System.Collections.Generic;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Views.Monster
{
    public partial class MonsterCreatePage : ContentPage
    {
        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
        }
    }
}
