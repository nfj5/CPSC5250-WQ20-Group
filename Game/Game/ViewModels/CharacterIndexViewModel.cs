﻿using System;
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
        //The sort order for the Character Model
        public List<CharacterModel> SortDataSet(List<CharacterModel> dataset)
        {
            return dataset.OrderBy(a => a.Name).ToList();
        }
        #endregion SortDataSet

        #region Methods 
        /// <summary>
        /// Returns the Character passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CharacterModel CheckIfExists(CharacterModel data)
        {
            // This will walk the Characters and find if there is one that is the same.
            // If so, it returns the Character...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name &&
                                        a.Description == data.Description &&
                                        a.Level == data.Level &&
                                        a.ExperiencePoints == data.ExperiencePoints &&
                                        a.BaseHitPoints == data.BaseHitPoints &&
                                        a.CurrentHitPoints == data.CurrentHitPoints
                                        )
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        #endregion SortDataSet
    }
}