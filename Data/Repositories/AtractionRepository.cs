using Microsoft.EntityFrameworkCore;
using tourismApp.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tourismApp.Data.Repositories
{
    public class AtractionRepository : IAtractionRepository
    {
        private readonly ApplicationDbContext _context;

        public AtractionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Atraction> GetAtractionById(int id)
        {
            return await _context.Atraction.FindAsync(id);
        }

        public async Task<Atraction> AddAtraction(Atraction entity)
        {
            await _context.Atraction.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task DeleteAtractionById(int id)
        {
            var atraction = await _context.Atraction.FindAsync(id);
            if (atraction != null)
            {
                _context.Atraction.Remove(atraction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Atraction> UpdateAtraction(Atraction entity)
        {
            _context.Atraction.Update(entity);
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task<IEnumerable<Atraction>> GetAllAtractions()
        {
            return await _context.Atraction.ToListAsync();
        }
    }
}
