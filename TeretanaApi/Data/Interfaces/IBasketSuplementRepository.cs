using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IBasketSuplementRepository
    {
        Task<List<BasketSuplement>> GetSuplementsAsync(Guid? basketId = null);
        Task<BasketSuplement> GetBasketSuplementByIdAsync(Guid basketId,Guid suplementId);
        Task<BasketSuplement> CreateBasketSuplementAsync(BasketSuplement basketSuplement);
        Task SaveChangesAsync();
        Task DeleteBasketSuplementByIdAsync(Guid basketId, Guid suplementId);
    }
}
