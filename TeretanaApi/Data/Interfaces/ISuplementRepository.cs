using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface ISuplementRepository
    {
        Task<List<Suplement>> GetSuplementsAsync(int page,int numOfPageResults,string name = null,string sortOrder = "",Guid? typeId = null);
        Task<List<Suplement>> GetSuplementsAsync();
        Task<Suplement> GetSuplementByIdAsync(Guid suplementId);
        Task<Suplement> GetSuplementByPriceIdAsync(string priceId);
        Task DeleteSuplementByIdAsync(Guid suplementId);
        Task<Suplement> CreateSuplementAsync(Suplement suplement);
        Task<int> GetSuplementCountAsync();
        Task SaveChangesAsync();
    }
}
