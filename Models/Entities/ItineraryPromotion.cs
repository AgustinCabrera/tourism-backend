namespace tourismApp.Models.Entities
{
    public class ItineraryPromotion
    {
        public int ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }

        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
