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
    public partial class PersonDiePage : ContentPage
    {

        // Handle Character death
        public PersonDiePage(PersonModel<CharacterModel> character)
        {
            InitializeComponent();
        }

        // Handle Monster death
        public PersonDiePage(PersonModel<MonsterModel> monster)
        {
            InitializeComponent();
        }
    }
}