namespace tourismApp.Models.Entities
{
    public class Promotion
    {
        public required Guid ID { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public required string PricingStrategy { get; set; }
        public required float Discount { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }

        

        public required ICollection<ItineraryPromotion> ItineraryPromotions { get; set; }

    }
}
