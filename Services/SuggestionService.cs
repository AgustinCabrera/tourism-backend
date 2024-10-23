// aca tengo la logica para obtener las preferencias del usuario, sugerir atracciones y crear un itinerario.

using tourismApp.Models.Entities;  
using tourismApp.Models.Requests;


namespace tourismApp.Services
{
    public class SuggestionService
    {
        private readonly ApplicationDbContext _dbContext;

        public SuggestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserPreferences GetUserPreferences(Guid userId)
        {
            var user = _dbContext.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            return new UserPreferences
            {
                PreferredAttractionTypeId = user.UserPreferredAttractionTypeId,
                Budget = user.UserBudget,
                AvailableTime = user.UserAvailableTime
            };
        }

        // Método para obtener sugerencias en base a las preferencias
        public List<Atraction> GetSuggestions(UserPreferences preferences)
        {
            var suggestedAttractions = _dbContext.Atraction
                .Where(a => a.TypeId == preferences.PreferredAttractionTypeId
                            && a.Cost <= preferences.Budget
                            && a.Duration <= preferences.AvailableTime)
                .ToList();

            return suggestedAttractions;
        }

        // Método para crear un itinerario basado en las atracciones seleccionadas
        public Itinerary CreateItinerary(Guid userId, List<Guid> selectedAttractions)
        {
            var user = _dbContext.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var attractions = _dbContext.Atraction
                .Where(a => selectedAttractions.Contains(a.AtractionId))
                .ToList();

            if (!attractions.Any())
            {
                throw new ArgumentException("No attractions found.");
            }

            var totalCost = attractions.Sum(a => a.Cost);

            var itinerary = new Itinerary
            {
                ItineraryID = Guid.NewGuid(),
                Name = "New Itinerary",
                UserId = userId,
                TotalCost = totalCost,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = "Created",
                Description = "Your personalized itinerary",
                ItineraryAtractions = attractions.Select(a => new ItineraryAtraction { AtractionId = a.AtractionId }).ToList()
            };

            _dbContext.Itinerary.Add(itinerary);
            _dbContext.SaveChanges();

            return itinerary;
        }
    }
}
