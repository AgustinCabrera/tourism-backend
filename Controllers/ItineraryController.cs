// maneja las peticiones de sugerencias de vistas e itinerarios

using Microsoft.AspNetCore.Mvc;
using tourismApp.Services;
using tourismApp.Models.Requests;
using tourismApp.Models;

namespace tourismApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly SuggestionService _suggestionService;

        public ItineraryController(SuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [HttpGet("suggestions/{userId}")]
        public IActionResult GetSuggestions(Guid userId)
        {
            var preferences = _suggestionService.GetUserPreferences(userId);
            var suggestions = _suggestionService.GetSuggestions(preferences);

            return Ok(suggestions);
        }

        [HttpPost("create-itinerary")]
        public IActionResult CreateItinerary([FromBody] ItineraryRequest request)
        {
            var itinerary = _suggestionService.CreateItinerary(request.UserId, request.SelectedAttractions);

            if (itinerary != null)
            {
                return Ok(itinerary);
            }

            return BadRequest("Could not create itinerary.");
        }
    }
}
