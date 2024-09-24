using tourismApp.Models.Entities;

namespace tourismApp.Data.Repositories
{
    public interface IAtractionRepository
    {
        Task<Atraction> GetAtractionById(int id);
        Task<IEnumerable<Atraction>> GetAllAtractions();
        Task<Atraction> AddAtraction(Atraction entity); 
        Task<Atraction> UpdateAtraction(Atraction entity); 
        Task DeleteAtractionByID(int id);

    }
}
