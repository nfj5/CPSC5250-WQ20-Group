namespace Game.Models
{
    /// <summary>
    /// Home Menu Item Model
    /// </summary>
    public class HomeMenuItemModel
    {
        // The current Menu Item
        public MenuItemEnum Id { get; set; }

        // Title for the page
        public string Title { get; set; }
    }
}