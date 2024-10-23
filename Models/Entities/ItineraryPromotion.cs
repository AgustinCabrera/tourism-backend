namespace tourismApp.Models.Entities
{
    public class ItineraryPromotion
    {
        public Guid ItineraryId { get; set; }
        public  Itinerary Itinerary { get; set; }

        public Guid PromotionId { get; set; }
        public  Promotion Promotion { get; set; }
    }
}
