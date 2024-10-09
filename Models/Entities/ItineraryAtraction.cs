namespace tourismApp.Models.Entities
{
    public class ItineraryAtraction
    {
        public Guid ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }

        public int AtractionId { get; set; }
        public Atraction Atraction { get; set; }
    }
}
