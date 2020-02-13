using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;
using Game.Views.Monster;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    public partial class MonsterIndexPage : ContentPage
    {
        readonly MonsterIndexViewModel ViewModel;

        public MonsterIndexPage()
        {
            //InitializeComponent();

            //BindingContext = ViewModel = MonsterIndexViewModel.Instance;
        }

        async void AddMonster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage(new ViewModels.GenericViewModel<Models.MonsterModel>())));
            
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            MonsterModel data = args.SelectedItem as MonsterModel;
            if (data == null)
            {
                return;
            }

            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));

            MonsterListView.SelectedItem = null;
        }

    }
}