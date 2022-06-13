using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly GymContext _context;

        public MembershipTypeRepository(GymContext context)
        {
            _context = context;
        }
        public async Task<MembershipType> CreateMembershipTypeAsync(MembershipType membership)
        {
            await _context.MembershipTypes.AddAsync(membership);
            return membership;
        }

        public async Task DeleteMembershipTypeByIdAsync(Guid membershipId)
        {
            var membership = await GetMembershipTypeByIdAsync(membershipId);
            _context.MembershipTypes.Remove(membership);
        }

        public async Task<MembershipType> GetMembershipTypeByIdAsync(Guid membershipId)
        {
            return await _context.MembershipTypes.FirstOrDefaultAsync(m => m.MembershipTypeId == membershipId);
        }

        public async Task<List<MembershipType>> GetMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToListAsync();
        }

        public async Task<MembershipType> GetMembershipTypeByPriceId(string priceId)
        {
            return await _context.MembershipTypes.FirstOrDefaultAsync(m => m.PriceId == priceId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
