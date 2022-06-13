using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IGroupTrainingRepository
    {
        Task<List<GroupTraining>> GetGroupTrainingsAsync();
        Task<GroupTraining> GetGroupTrainingByIdAsync(Guid groupTrainingId);
        Task DeleteGroupTrainingByIdAsync(Guid groupTrainingId);
        Task<GroupTraining> CreateGroupTrainingAsync(GroupTraining groupTraining);
        Task<List<GroupTraining>> GetGroupTrainingsByTrainer(Guid trainerId);
        Task SaveChangesAsync();
    }
}
