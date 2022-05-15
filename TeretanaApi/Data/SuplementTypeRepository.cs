using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class SuplementTypeRepository : ISuplementTypeRepository
    {
        private readonly GymContext _context;

        public SuplementTypeRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<SuplementType> CreateSuplementTypeAsync(SuplementType suplementType)
        {
            await _context.SuplementTypes.AddAsync(suplementType);
            return suplementType;
        }

        public async Task DeleteSuplementTypesByIdAsync(Guid SuplementTypeId)
        {
            var suplementType = await GetSuplementTypesByIdAsync(SuplementTypeId);
            _context.SuplementTypes.Remove(suplementType);
        }

        public async Task<List<SuplementType>> GetSuplementTypesAsync()
        {
            return await _context.SuplementTypes.ToListAsync();
        }

        public async Task<SuplementType> GetSuplementTypesByIdAsync(Guid SuplementTypeId)
        {
            return await _context.SuplementTypes.FirstOrDefaultAsync(s => s.SuplementTypeId == SuplementTypeId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
