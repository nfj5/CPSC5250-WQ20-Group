using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Hold the Details for each Level
    /// </summary>
    class LevelDetailsModel
    {
        // The Level
        public int Level;

        // Experience points to achieve the level
        public int Experience;

        // Attack Bonus
        public int Strength;

        // Defense Bonus
        public int Thiccness;

        // Speed Bonus
        public int Speed;

        //Stamina bonus.
        public int Stamina;

        //Hitpoints Bonus
        public int Hitpoints;

        //SuperStar bonus
        public int Superstar;

        /// <summary>
        /// Create a new level based on values passed in
        /// </summary>
        /// <param name="level"></param>
        /// <param name="experience"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        public LevelDetailsModel(int level, int experience, int strength, int thiccness, int speed, int stamimna, int hitpoints, int superstar)
        {
            Level = level;
            Experience = experience;
            Strength = strength;
            Thiccness = thiccness;
            Speed = speed;
            Stamina = stamimna;
            Hitpoints = hitpoints;
            Superstar = superstar;

        }
    }
}