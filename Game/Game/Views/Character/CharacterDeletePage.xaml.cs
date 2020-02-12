﻿using Game.Models;
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

        async void Delete_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}