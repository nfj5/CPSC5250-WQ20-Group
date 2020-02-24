namespace Game.Models
{
    public enum ItemLocationEnum
    {
        // Not specified
        Unknown = 0,

        // The head includes, Hats, Helms, Caps, Crowns, Hair Ribbons, Bunny Ears, and anything else that sits on the head
        ItemOne = 10,

        // Things to put around the neck, such as necklass, broaches, scarfs, neck ribbons.  Can have at the same time with Head items ex. Ribbon for Hair, and Ribbon for Neck is OK to have
        ItemTwo = 12,

        // The primary hand used for fighting with a sword or a staff.  
        ItemThree = 20,

        // The second hand used for holding a shield or dagger, or wand.  OK to have both primary and offhand loaded at the same time
        ItemFour = 22,

        // Any finger, used for rings, because they can go on any finger.
        ItemFive = 30,

        // A finger on the Right hand for rings.  Can only have one right on the right hand
        ItemSix = 31,

    }
}