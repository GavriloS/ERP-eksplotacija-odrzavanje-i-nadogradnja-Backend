using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IMembershipRepository
    {
        Task<List<Membership>> GetMembershipsAsync(Guid? userId = null);
        Task<Membership> GetMembershipByIdAsync(Guid MembershipId);
        Task DeleteMembershipByIdAsync(Guid MembershipId);
        Task<Membership> CreateMembershipAsync(Membership Memberships);
        Task SaveChangesAsync();
    }
}
