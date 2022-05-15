using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task DeleteUserByIdAsync(Guid userId);
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}
