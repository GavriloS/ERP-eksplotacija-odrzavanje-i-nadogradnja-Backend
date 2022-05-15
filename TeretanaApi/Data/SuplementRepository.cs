using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class SuplementRepository : ISuplementRepository
    {

        private readonly GymContext _context;

        public SuplementRepository(GymContext context)
        {
            _context = context;
        }
        public async Task<Suplement> CreateSuplementAsync(Suplement suplement)
        {
            await _context.Suplements.AddAsync(suplement);
            return suplement;
        }

        public async Task DeleteSuplementByIdAsync(Guid suplementId)
        {
            var suplement = await GetSuplementByIdAsync(suplementId);
            _context.Suplements.Remove(suplement);
        }

        public async Task<Suplement> GetSuplementByIdAsync(Guid suplementId)
        {
            return await _context.Suplements.Include(st => st.SuplementType).FirstOrDefaultAsync(s => s.SuplementId == suplementId);
        }

        public async Task<List<Suplement>> GetSuplementsAsync(int page, int numOfPageResults,string name = null)
        {
            return await _context.Suplements.Include(st => st.SuplementType).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(s => (name == null || s.Name.Contains(name))).ToListAsync();
        }
        public async Task<int> GetSuplementCountAsync()
        {
            return await _context.Suplements.CountAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
