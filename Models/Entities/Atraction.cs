namespace tourismApp.Models.Entities
{
    public class Atraction
    {
        public required int AtractionId{ get; set; }
        public required string AtractionName { get; set; }
        public required string AtractionDescription { get; set; }
        public required decimal AtractionCost { get; set; }
        public required int AtractionTypeId { get; set; }
        public required bool IsAtractionDeleted { get; set; }


        
    }
}
