using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Helper to manage the Level Table Data
    /// </summary>
    class LevelTableHelper
    {
        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static LevelTableHelper _instance;

        public static LevelTableHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LevelTableHelper();
                }
                return _instance;
            }
        }

        #endregion Singleton

        // Level Max
        public const int MaxLevel = 20;

        // List of all the levels
        public List<LevelDetailsModel> LevelDetailsList { get; set; }

        /// <summary>
        /// Constructor calls to clear the data
        /// </summary>
        public LevelTableHelper()
        {
            ClearAndLoadDatTable();
        }

        /// <summary>
        /// Clear the data and relaod it
        /// </summary>
        public void ClearAndLoadDatTable()
        {
            LevelDetailsList = new List<LevelDetailsModel>();
            LoadLevelData();
        }

        /// <summary>
        /// Load the data for each level
        /// </summary>
        public void LoadLevelData()
        {
            // Init the level list, going to index into it like an array, so making 0 be a null value.  That way Level can be Array Index.
            LevelDetailsList.Add(new LevelDetailsModel(0, 0, 0, 0, 0, 0, 0,0));

            // Character Level Chart...

            // Sequence is Level,Experince,Strength,Thiccness(defense),Speed,Stamina,Hit Points, SuperStart

            LevelDetailsList.Add(new LevelDetailsModel(0, 1, 1, 0, 0, 0, 1, 0));
            LevelDetailsList.Add(new LevelDetailsModel(300, 2, 1, 1, 0, 0, 2, 0));
            LevelDetailsList.Add(new LevelDetailsModel(900, 3, 1, 1, 1, 0, 3, 0));
            LevelDetailsList.Add(new LevelDetailsModel(2700, 4, 1, 1, 1, 1, 4, 0));
            LevelDetailsList.Add(new LevelDetailsModel(6500, 5, 1, 1, 1, 1, 5, 1));
            LevelDetailsList.Add(new LevelDetailsModel(14000, 6, 2, 1, 1, 1, 6, 1));
            LevelDetailsList.Add(new LevelDetailsModel(23000, 7, 2, 2, 1, 1, 7, 1));
            LevelDetailsList.Add(new LevelDetailsModel(34000, 8, 2, 2, 2, 1, 8, 1));
            LevelDetailsList.Add(new LevelDetailsModel(48000, 9, 2, 2, 2, 2, 9, 1));
            LevelDetailsList.Add(new LevelDetailsModel(64000, 10, 2, 2, 2, 2, 10, 2));
            LevelDetailsList.Add(new LevelDetailsModel(85000, 11, 3, 2, 2, 2, 11, 2));
            LevelDetailsList.Add(new LevelDetailsModel(100000, 12, 3, 3, 2, 2, 12, 2));
            LevelDetailsList.Add(new LevelDetailsModel(120000, 13, 3, 3, 3, 2, 13, 2));
            LevelDetailsList.Add(new LevelDetailsModel(140000, 14, 3, 3, 3, 3, 14, 2));
            LevelDetailsList.Add(new LevelDetailsModel(165000, 15, 4, 3, 3, 3, 15, 2));
            LevelDetailsList.Add(new LevelDetailsModel(195000, 16, 4, 4, 3, 3, 16, 2));
            LevelDetailsList.Add(new LevelDetailsModel(225000, 17, 4, 4, 4, 3, 17, 3));
            LevelDetailsList.Add(new LevelDetailsModel(265000, 18, 4, 4, 4, 4, 18, 3));
            LevelDetailsList.Add(new LevelDetailsModel(305000, 18, 5, 4, 4, 4, 18, 3));
            LevelDetailsList.Add(new LevelDetailsModel(305000, 19, 5, 5, 4, 4, 19, 3));
            LevelDetailsList.Add(new LevelDetailsModel(355000, 20, 5, 5, 5, 4, 20, 3));


        }
    }
}