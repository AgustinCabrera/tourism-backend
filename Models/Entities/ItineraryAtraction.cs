namespace tourismApp.Models.Entities
{
    public class ItineraryAtraction
    {
        public int ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }

        public int AtractionId { get; set; }
        public Atraction Atraction { get; set; }
    }
}
