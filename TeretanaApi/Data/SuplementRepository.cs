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

        public async Task<List<Suplement>> GetSuplementsAsync(int page, int numOfPageResults,string name = null,string sortOrder = "",Guid? typeId = null)
        {
            switch (sortOrder)
            {
                case "price_desc":
                 
                    return await _context.Suplements.Include(st => st.SuplementType).OrderByDescending(s => s.Price).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(s => (name == null || s.Name.Contains(name)) && (typeId == null || s.SuplementTypeId == typeId)).ToListAsync();

                case "price_asc":
                    return await _context.Suplements.Include(st => st.SuplementType).OrderBy(s => s.Price).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(s => (name == null || s.Name.Contains(name)) && (typeId == null || s.SuplementTypeId == typeId)).ToListAsync();

                  
                default:
                    return await _context.Suplements.Include(st => st.SuplementType).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(s => (name == null || s.Name.Contains(name)) && (typeId == null || s.SuplementTypeId == typeId)).ToListAsync();

                   
            }
        }
        public async Task<List<Suplement>> GetSuplementsAsync()
        {
            return await _context.Suplements.Include(s => s.SuplementType).ToListAsync();
        }
        public async Task<int> GetSuplementCountAsync()
        {
            return await _context.Suplements.CountAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Suplement> GetSuplementByPriceIdAsync(string priceId)
        {
            return await _context.Suplements.Include(s => s.SuplementType).FirstOrDefaultAsync(s => s.PriceId == priceId);
        }
    }
}
