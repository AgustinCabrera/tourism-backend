using Microsoft.EntityFrameworkCore;
using tourismApp.Models.Entities;

namespace tourismApp.Data.Repositories
{
    public class AtractionRepository : IAtractionRepository
    {
        private readonly ApplicationDbContext _context;
        public AtractionRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<Atraction> GetAtractionById(int id)
        {
            return await _context.Atraction.FindAsync(id);
        }
        public async Task<IEnumerable<Atraction>> GetAllAtractions()
        {
            return await _context.Atraction.ToListAsync();
        }
        public async Task AddAtraction(Atraction entity)
        {
            await _context.Atraction.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAtraction(Atraction entity)
        {
            _context.Atraction.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAtractionByID(int id)
        {
            var atraction = await _context.Atraction.FindAsync(id);
            if(atraction != null)
            {
                _context.Atraction.Remove(atraction);
                await _context.SaveChangesAsync();
            }  
        }

    }
}
