using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly GymContext _context;

        public MembershipRepository(GymContext context)
        {
            _context = context;
        }


         public async Task<Membership> CreateMembershipAsync(Membership userMemberships)
        {
           await _context.Memberships.AddAsync(userMemberships);
            return userMemberships;
        }

        public async Task DeleteMembershipByIdAsync(Guid userMembershipId)
        {
            var userMembership = await GetMembershipByIdAsync(userMembershipId);
            _context.Memberships.Remove(userMembership);
        }

        public async Task<List<Membership>> GetMembershipsAsync(Guid? userId = null)
        {
            return await _context.Memberships.Include(m => m.User).Include(m => m.MembershipType).Where(u => (userId == null || u.UserId == userId)).ToListAsync();
        }

        public async Task<Membership> GetMembershipByIdAsync(Guid userMembershipId)
        {
            return await _context.Memberships.Include(m => m.User).Include(m => m.MembershipType).FirstOrDefaultAsync(u => u.MembershipId == userMembershipId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
