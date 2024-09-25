namespace tourismApp.Models.Entities
{
    public class Atraction

    {
        public required int AtractionId{ get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Cost { get; set; }
        public required int TypeId { get; set; }
        public required bool IsDeleted { get; set; }
        public required int Duration { get; set; }


        public required ICollection<ItineraryAtraction> ItineraryAtractions { get; set; }
        
    }
}
