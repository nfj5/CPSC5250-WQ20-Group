using System;
using System.Collections.Generic;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        GenericViewModel<MonsterModel> ViewModel { get; set; }

        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            data.Data = new MonsterModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";
        }

        /// <summary>
        /// Save the new Monster by calling Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Make sure that they are providing information for required fields
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await DisplayAlert("Invalid format", "Monster must have a name and description.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.MonsterService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel Monster creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Capture value change for Speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Capture value change for Strength stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Strength_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            StrengthValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for HitPoints stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HitPoints_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            HitPointsValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for HitPoints stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Thiccness_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ThiccnessValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        ///  Capture value change for HitPoints stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Stamina_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            StaminaValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}
