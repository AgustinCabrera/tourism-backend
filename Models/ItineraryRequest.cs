namespace tourismApp.Models
{
    public class ItineraryRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> SelectedAttractions { get; set; }
    }
}
