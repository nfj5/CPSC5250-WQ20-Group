using System;
using System.Collections.Generic;
using System.Linq;
using Game.Models;
using Game.Services;
using Game.Views;
using Game.Views.Monster;
using Xamarin.Forms;

namespace Game.ViewModels
{
    public class MonsterIndexViewModel : BaseViewModel<MonsterModel>
    {
        #region Singleton

        private static volatile MonsterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static MonsterIndexViewModel Instance
        {
            get {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MonsterIndexViewModel();
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
        public MonsterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            //Register the create message
            MessagingCenter.Subscribe<MonsterCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as MonsterModel);
            });

            //Register the Update message
            MessagingCenter.Subscribe<MonsterUpdatePage, MonsterModel>(this, "update", async (obj, data) =>
            {
                data.Update(data);
                await UpdateAsync(data as MonsterModel);
            });

            //Register the Delete message
            MessagingCenter.Subscribe<MonsterDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            {

                await DeleteAsync(data as MonsterModel);
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
        public MonsterModel CheckIfItemExists(MonsterModel data)
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
        public override List<MonsterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new MonsterModel());
        }

        #endregion DataOperations_CRUDI

        #region SortDataSet
        //The sort order for the Character Model
        public List<MonsterModel> SortDataSet(List<MonsterModel> dataset)
        {
            return dataset.OrderBy(a => a.Name).ToList();
        }
        #endregion SortDataSet
    }
}
