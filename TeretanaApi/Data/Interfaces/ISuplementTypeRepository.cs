using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface ISuplementTypeRepository
    {
        Task<List<SuplementType>> GetSuplementTypesAsync();
        Task <SuplementType> GetSuplementTypesByIdAsync(Guid SuplementTypeId);
        Task DeleteSuplementTypesByIdAsync(Guid SuplementTypeId);
        Task<SuplementType> CreateSuplementTypeAsync(SuplementType suplementType);
        Task SaveChangesAsync();
    }
}
