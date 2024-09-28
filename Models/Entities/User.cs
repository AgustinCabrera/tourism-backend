namespace tourismApp.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public  bool UserEmailConfirmed { get; set; }
        public required string UserPassword { get; set; }
        public  decimal UserGold { get; set; }
        public  decimal UserAvailableTime {  get; set; }
        public  int UserPreferredAttractionTypeId { get; set; }
        public  bool IsUserAdmin { get; set; }
        public  decimal UserBudget { get; set; }
      


        public  ICollection<Itinerary> Itineraries { get; set; }
        
    }
}
