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
    /// <summary>
    /// The Monster Update Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {

        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for UTs
        public MonsterUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for MonsterUpdatePage by taking a view model of Monster to update
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }


        /// <summary>
        /// Save the updated Monster 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // Make sure that they are providing information for required fields
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await DisplayAlert("Invalid format", "Monster must have a name and description.", "OK");
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel Monster update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Capture value change for Speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Capture value change for Strength stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Strength_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            StrengthValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for HitPoints stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HitPoints_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            HitPointsValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for Thiccness stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Thiccness_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ThiccnessValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for Stamina stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Stamina_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            StaminaValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for Level stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}