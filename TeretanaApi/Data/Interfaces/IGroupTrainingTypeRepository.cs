using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IGroupTrainingTypeRepository
    {
        Task<List<GroupTrainingType>> GetGroupTrainingTypesAsync();
        Task<GroupTrainingType> GetGroupTrainingTypeByIdAsync(Guid groupTrainingId);
        Task DeleteGroupTrainingTypeAsync(Guid groupTrainingId);
        Task <GroupTrainingType> CreateGroupTrainingTypeAsync(GroupTrainingType groupTrainingType);
        Task SaveChangesAsync();
    }
}
