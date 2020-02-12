using System;
using Game.Models;
using Game.Views;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;
namespace Game.ViewModels
{
    //Character view Model
    //Manages the list of data records
    public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
    {
        #region Singleton

        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region Constructor

        //Constructor
        //The constructor subscribes message listeners for crudi operations
        public CharacterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            //Register the create message
            MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as CharacterModel);
            });

            //Register the Update message
            MessagingCenter.Subscribe<CharacterUpdatePage, CharacterModel>(this, "update", async (obj, data) =>
            {
                data.Update(data);
                await UpdateAsync(data as CharacterModel);
            });

            //Register the Delete message
            MessagingCenter.Subscribe<CharacterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
            {
                
                await DeleteAsync(data as CharacterModel);
            });

            //Register the Set data source message
            MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            {

                await SetDataSource(data);
            });

            //Register the Wipe data source message
            MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            {
                await WipeDataListAsync();
            });

            #endregion Messages
        }

        #endregion Constructor

        #region DataOperations_CRUDI

        //Returns items passed in
        public CharacterModel CheckIfItemExists(CharacterModel data)
        {
            var myList = Dataset.Where(a => a.Name == data.Name).FirstOrDefault();

            if (myList == null)
            {
                // its not a math, return false;
                return null;
            }

            return myList;
        }

        //Load the defual data
        public override List<CharacterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new CharacterModel());
        }

        #endregion DataOperations_CRUDI

        #region SortDataSet
    }
}