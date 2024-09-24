using tourismApp.Models.Entities;

namespace tourismApp.Services
{
    public class AtractionService : IAtractionService
    {
        private readonly IAtractionService _atractionService;
        public AtractionService(IAtractionService atractionService)
        {
            _atractionService = atractionService;
        }
        public async Task<Atraction> GetAtractionById(int id)
        {
            return await _atractionService.GetAtractionById(id);
        } 
        public async Task<IEnumerable<Atraction>> GetAllAtractions()
        {
            return await _atractionService.GetAllAtractions();
        }
        public async Task AddAtraction(Atraction atraction)
        {
            await _atractionService.AddAtraction(atraction);
        }
        public async Task UpdateAtraction(Atraction atraction)
        {
            await _atractionService.UpdateAtraction(atraction);
        }
        public async Task DeleteAtraction(int id)
        {
            await _atractionService.DeleteAtraction(id);
        }

    }
}
