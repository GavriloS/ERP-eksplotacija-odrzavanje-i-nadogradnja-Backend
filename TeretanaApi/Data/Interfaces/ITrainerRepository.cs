using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface ITrainerRepository
    {
        Task<List<Trainer>> GetTrainersAsync();
        Task<Trainer> GetTrainerByIdAsync(Guid trainerId);
        Task DeleteTrainerById(Guid trainerId);
        Task<Trainer> CreateTrainerAsync(Trainer trainer);
        Task SaveChangesAsync();
    }
}
