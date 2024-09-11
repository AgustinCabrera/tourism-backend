namespace tourismApp.Models.Entities
{
    public class Promotion
    {
        public required int PromotionID { get; set; }
        public required int AtractionId { get; set; }
        public required string PromotionDescription { get; set; }
        public required string PromotionType { get; set; }
        public required string PromotionPricingStrategy { get; set; }
        public required float PromotionCostOrDiscount { get; set; }
        public required bool IsPromotionDeleted { get; set; }

    }
}
