using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(Guid userTypeId);
        Task SaveChangesAsync();
    }
}
