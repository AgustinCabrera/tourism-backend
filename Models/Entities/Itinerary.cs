namespace tourismApp.Models.Entities
{
    public class Itinerary
    {
        public required int  UserId { get; set; }
        public required int ItineraryID { get; set; }
        public required int AtractionId { get; set; }

    }
}
