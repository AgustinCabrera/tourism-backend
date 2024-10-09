namespace tourismApp.Models.Entities
{
    public class Itinerary
    {
        public  Guid ItineraryID { get; set; }
        public string Name { get; set; }
        public  decimal TotalCost { get; set; }
        public decimal RemainingBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string Status { get; set; }
        public  string Description { get; set; }


        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public required ICollection<ItineraryAtraction> ItineraryAtractions { get; set; }
        public required ICollection<ItineraryPromotion> ItineraryPromotions { get; set; }
    }
}
