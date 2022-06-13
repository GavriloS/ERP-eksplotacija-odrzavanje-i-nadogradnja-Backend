using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class GroupTrainingRepository : IGroupTrainingRepository
    {
        private readonly GymContext _context;

        public GroupTrainingRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<GroupTraining> CreateGroupTrainingAsync(GroupTraining groupTraining)
        {
            await _context.GroupTrainings.AddAsync(groupTraining);
            return groupTraining;
        }

        public async Task DeleteGroupTrainingByIdAsync(Guid groupTrainingId)
        {
            var groupTraining = await GetGroupTrainingByIdAsync(groupTrainingId);
            _context.GroupTrainings.Remove(groupTraining);
        }

        public async Task<GroupTraining> GetGroupTrainingByIdAsync(Guid groupTrainingId)
        {
            return await _context.GroupTrainings.Include(g => g.Trainer).Include(g => g.GroupTrainingType).Include(g => g.Users).FirstOrDefaultAsync(g => g.GroupTrainingId == groupTrainingId);
        }

        public async Task<List<GroupTraining>> GetGroupTrainingsAsync()
        {
            return await _context.GroupTrainings.Include(g => g.Trainer).Include(g => g.Users).Include(g => g.GroupTrainingType).ToListAsync();
        }
        public async Task<List<GroupTraining>> GetGroupTrainingsByTrainer(Guid trainerId)
        {
            return await _context.GroupTrainings.Include(g => g.Trainer).Include(g => g.Users).Include(g => g.GroupTrainingType).Where(g => g.TrainerId == trainerId).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
