using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Hold the Details for each Level
    /// </summary>
    public class LevelDetailsModel
    {
        // The Level
        public int Level;

        // Experience points to achieve the level
        public int Experience;

        // Strength Bonus
        public int Strength;

        // Defense Bonus
        public int Thiccness;

        // Speed Bonus
        public int Speed;

        //Stamina Bonus
        public int Stamina;

        //HitPoints Bonus
        public int Hitpoints;

        //SuperStar Abilty Bonus
        public int Superstar;

        /// <summary>
        /// Create a new level based on values passed in
        /// </summary>
        /// <param name="level"></param>
        /// <param name="experience"></param>
        /// <param name="strength"></param>
        /// <param name="thiccness"></param>
        /// <param name="speed"></param>
        public LevelDetailsModel(int experience, int level, int strength,
            int thiccness, int speed, int stamina, int hitpoints, int superstar)
        {
            Experience = experience;
            Level = level;
            Strength = strength;
            Thiccness = thiccness;
            Speed = speed;
            Stamina = stamina;
            Hitpoints = hitpoints;
            Superstar = superstar;
        }
    }
}