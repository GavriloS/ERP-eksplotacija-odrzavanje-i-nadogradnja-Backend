using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class GroupTrainingTypeRepository : IGroupTrainingTypeRepository
    {
        private readonly GymContext _context;

        public GroupTrainingTypeRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<GroupTrainingType> CreateGroupTrainingTypeAsync(GroupTrainingType groupTrainingType)
        {
            await _context.GroupTrainingTypes.AddAsync(groupTrainingType);
            return groupTrainingType;
        }

        public async Task DeleteGroupTrainingTypeAsync(Guid groupTrainingId)
        {
            var groupTrainingType = await GetGroupTrainingTypeByIdAsync(groupTrainingId);
            _context.GroupTrainingTypes.Remove(groupTrainingType);
        }

        public async Task<GroupTrainingType> GetGroupTrainingTypeByIdAsync(Guid groupTrainingId)
        {
            return await _context.GroupTrainingTypes.FirstOrDefaultAsync(g => g.GroupTrainingTypeId == groupTrainingId);
        }

        public async Task<List<GroupTrainingType>> GetGroupTrainingTypesAsync()
        {
            return await _context.GroupTrainingTypes.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
