using Game.Models;
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
    public partial class PlayerDiePage : ContentPage
    {
        // Handle Character death
        public PlayerDiePage(PersonModel<CharacterModel> character)
        {
            InitializeComponent();
        }

        // Handle Monster death
        public PlayerDiePage(PersonModel<MonsterModel> monster)
        {
            InitializeComponent();
        }
    }
}