using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    public partial class MonsterIndexPage : ContentPage
    {
        // The Monster Index view model
        readonly MonsterIndexViewModel ViewModel;

        // Empty Constructor for UTs
        public MonsterIndexPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Monster index page
        /// 
        /// Gets the current MonsterIndexViewModel
        /// </summary>
        public MonsterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = MonsterIndexViewModel.Instance;
        }

        /// <summary>
        /// Add a new Monster 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddMonster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage(new ViewModels.GenericViewModel<Models.MonsterModel>())));
            
        }

        /// <summary>
        /// Read a selected Monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            MonsterModel data = args.SelectedItem as MonsterModel;
            if (data == null)
            {
                return;
            }

            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(data)));

            MonsterListView.SelectedItem = null;
        }

        /// <summary>
        /// Refreshes the list view after adding or deleting a Character
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            // If no data, then set it for needing refresh
            if (ViewModel.Dataset.Count == 0)
            {
                ViewModel.SetNeedsRefresh(true);
            }

            // If the needs Refresh flag is set update it
            if (ViewModel.NeedsRefresh())
            {
                ViewModel.LoadDatasetCommand.Execute(null);
            }

            BindingContext = ViewModel;
        }

    }
}