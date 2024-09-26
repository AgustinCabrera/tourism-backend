namespace tourismApp.Models.Entities
{
    public class ItineraryPromotion
    {
        public int ItineraryId { get; set; }
        public required Itinerary Itinerary { get; set; }

        public int PromotionId { get; set; }
        public required Promotion Promotion { get; set; }
    }
}
