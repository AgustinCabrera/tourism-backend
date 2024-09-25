namespace tourismApp.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string UserPassword { get; set; }
        public required decimal UserGold { get; set; }
        public required decimal UserAvailableTime {  get; set; }
        public required int UserPreferredAttractionTypeId { get; set; }
        public required bool IsUserAdmin { get; set; }
        public required decimal UserBudget { get; set; }


        public required ICollection<Itinerary> Itineraries { get; set; }
        
    }
}
