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
    public partial class CharacterCreatePage : ContentPage
    {
        GenericViewModel<CharacterModel> ViewModel { get; set; }

        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            data.Data = new CharacterModel();

            BindingContext = this.ViewModel = data;
            
            this.ViewModel.Title = "Create";

            
            AbilityPicker.SelectedItem = data.Data.Ability.ToString();
        }
        
        /// <summary>
        /// Save the new Character by calling Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.CharacterService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel Character creation
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