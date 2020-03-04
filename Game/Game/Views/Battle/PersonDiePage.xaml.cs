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
    public partial class PersonDiePage : ContentPage
    {
        GenericViewModel<CharacterModel> CharacterViewModel;
        GenericViewModel<MonsterModel> MonsterViewModel;

        // Handle Character death
        public PersonDiePage(GenericViewModel<CharacterModel> character)
        {
            InitializeComponent();

            character.Data = new CharacterModel();

            BindingContext = this.CharacterViewModel = character;
        }

        // Handle Monster death
        public PersonDiePage(GenericViewModel<MonsterModel> monster)
        {
            InitializeComponent();

            monster.Data = new MonsterModel();

            BindingContext = this.MonsterViewModel = monster;
        }

        // Go back to the Battle screen
        public async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}