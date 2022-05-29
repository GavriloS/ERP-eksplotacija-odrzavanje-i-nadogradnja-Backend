using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetBasketsAsync();
        Task<Basket> GetBasketByIdAsync(Guid basketId);
        Task DeleteBasketByIdAsync(Guid basketId);
        Task<Basket> CreateBasketAsync(Basket basket);
        Task<List<Basket>> GetBasketsByUser(Guid userId);
        Task<Basket> GetOpenBasketByUser(Guid userId);
        Task SaveChangesAsync();
    }
}
