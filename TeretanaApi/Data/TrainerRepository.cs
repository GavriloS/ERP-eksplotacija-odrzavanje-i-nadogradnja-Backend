using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly GymContext _context;

        public TrainerRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<Trainer> CreateTrainerAsync(Trainer trainer)
        {
            await _context.Trainers.AddAsync(trainer);
            return trainer;
        }

        public async Task DeleteTrainerById(Guid trainerId)
        {
            var trainer = await GetTrainerByIdAsync(trainerId);
            _context.Trainers.Remove(trainer);
        }

        public async Task<Trainer> GetTrainerByIdAsync(Guid trainerId)
        {
            return await _context.Trainers.FirstOrDefaultAsync(t => t.TrainerId == trainerId);
            
        }

        public async Task<List<Trainer>> GetTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
