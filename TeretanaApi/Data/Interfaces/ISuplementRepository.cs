using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface ISuplementRepository
    {
        Task<List<Suplement>> GetSuplementsAsync(int page,int numOfPageResults,string name = null);
        Task<Suplement> GetSuplementByIdAsync(Guid suplementId);
        Task DeleteSuplementByIdAsync(Guid suplementId);
        Task<Suplement> CreateSuplementAsync(Suplement suplement);
        Task<int> GetSuplementCountAsync();
        Task SaveChangesAsync();
    }
}
