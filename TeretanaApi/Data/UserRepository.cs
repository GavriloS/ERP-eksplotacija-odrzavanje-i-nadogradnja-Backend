using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly GymContext _context;

        public UserRepository(GymContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task DeleteUserByIdAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);
            _context.Users.Remove(user);
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.Include(u => u.UserType).Include(u => u.Address).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.Include(u => u.UserType).Include(u => u.Address).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.UserType).Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
