namespace Game.Models
{
    public enum PersonJobEnum
    {
        // Not specified
        Unknown = 0,

        //Qbs throw the ball better then the rest.
        QB = 10,

        // Rbs run faster then everyone else
        RB = 12,

        // WRs catch the ball better then everyone else.   
        WR = 20,


    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class PersonJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this PersonJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case PersonJobEnum.QB:
                    Message = "Quarter back";
                    break;

                case PersonJobEnum.RB:
                    Message = "Running back";
                    break;

                case PersonJobEnum.WR:
                    Message = "Wide Receiver";
                    break;

                case PersonJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}