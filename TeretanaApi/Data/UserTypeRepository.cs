using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly GymContext _context;

        public UserTypeRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<UserType> GetUserTypeByIdAsync(Guid userTypeId)
        {
            return await _context.UserTypes.FirstOrDefaultAsync(u => u.UserTypeId == userTypeId);
        }

        public async Task<List<UserType>> GetUserTypesAsync()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
