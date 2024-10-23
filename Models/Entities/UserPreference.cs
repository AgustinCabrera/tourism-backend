namespace tourismApp.Models.Entities
{
    public class UserPreference
    {
        public Guid UserID { get; set; }
        public User User { get; set; }
        public int PreferredAttractionTypeID { get; set; }
        public decimal MaxBudget { get; set; }
        public int AvailableTime {  get; set; }
        
    }
}
