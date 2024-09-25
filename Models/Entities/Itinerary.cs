namespace tourismApp.Models.Entities
{
    public class Itinerary
    {
        public required int ItineraryID { get; set; }
        public required decimal TotalCost { get; set; }
        public required decimal RemainingBudget { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Status { get; set; }
        public required string Description { get; set; }


        public required int UserId { get; set; }
        public required User User { get; set; }

        public required ICollection<ItineraryAtraction> ItineraryAtractions { get; set; }
        public required ICollection<ItineraryPromotion> ItineraryPromotions { get; set; }
    }
}
