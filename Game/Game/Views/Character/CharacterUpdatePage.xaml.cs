using Game.Models;
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
    public partial class CharacterUpdatePage : ContentPage
    {

        //Change to characterviewmodel viewmodel;
        GenericViewModel<CharacterModel> ViewModel;


        /// <summary>
        /// Constructor for CharacterUpdatePage by taking a view model of character to update
        /// </summary>
        /// <param name="data"></param>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            AbilityPicker.SelectedItem = data.Data.Ability.ToString();
        }

        /// <summary>
        /// Save the updated Character 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Make sure that they are providing information for required fields
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                await DisplayAlert("Invalid format", "Character must have a name and description.", "OK");
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel Character update
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
        ///  Capture value change for Thiccness stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Thiccness_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
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

    }
}