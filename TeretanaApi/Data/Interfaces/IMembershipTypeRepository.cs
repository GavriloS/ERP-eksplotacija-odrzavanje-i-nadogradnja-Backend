using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IMembershipTypeRepository
    {
        Task<List<MembershipType>> GetMembershipTypesAsync();
        Task<MembershipType> GetMembershipTypeByIdAsync(Guid membershipId);
        Task DeleteMembershipTypeByIdAsync(Guid membershipId);
        Task<MembershipType> CreateMembershipTypeAsync(MembershipType membership);
        Task<MembershipType> GetMembershipTypeByPriceId(string priceId);
        Task SaveChangesAsync();
    }
}
