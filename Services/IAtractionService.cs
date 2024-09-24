using tourismApp.Models.Entities;

namespace tourismApp.Services
{
    public interface IAtractionService
    {
        Task<Atraction> GetAtractionById(int id);
        Task<IEnumerable<Atraction>> GetAllAtractions();
        Task AddAtraction(Atraction entity);
        Task UpdateAtraction(Atraction entity);
        Task DeleteAtraction(int id);
    }
}
