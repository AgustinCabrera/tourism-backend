using tourismApp.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tourismApp.Data.Repositories
{
    public interface IAtractionRepository
    {
        Task<Atraction> GetAtractionById(int id);
        Task<Atraction> AddAtraction(Atraction entity);
        Task DeleteAtractionById(int id);
        Task<Atraction> UpdateAtraction(Atraction entity);
        Task<IEnumerable<Atraction>> GetAllAtractions();
    }
}
