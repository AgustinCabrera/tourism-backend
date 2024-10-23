namespace tourismApp.Models.Requests
{
    public class UserPreferences
    {
        public int PreferredAttractionTypeId { get; set; }
        public decimal Budget { get; set; }
        public decimal AvailableTime { get; set; }
    }
}
