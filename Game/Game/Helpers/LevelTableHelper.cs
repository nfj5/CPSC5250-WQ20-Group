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
            LevelDetailsList.Add(new LevelDetailsModel(0, 0, 0, 0, 0, 0, 0, 0));
            

            // Character Level Chart...

            // Sequence is Level,Experince,Strength,Thiccness(defense),Speed,Stamina,Hit Points, SuperStart

            
        }
    }
}