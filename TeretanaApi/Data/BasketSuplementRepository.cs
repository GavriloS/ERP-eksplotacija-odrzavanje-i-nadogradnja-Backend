using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class BasketSuplementRepository : IBasketSuplementRepository
    {
        private readonly GymContext context;
        public BasketSuplementRepository(GymContext context)
        {
            this.context = context;
        }

        public async Task<BasketSuplement> CreateBasketSuplementAsync(BasketSuplement basketSuplement)
        {
            await context.BasketSuplement.AddAsync(basketSuplement);
            return basketSuplement;
        }

        public async Task DeleteBasketSuplementByIdAsync(Guid basketId, Guid suplementId)
        {
            var basketSuplement = await GetBasketSuplementByIdAsync(basketId, suplementId);
            context.BasketSuplement.Remove(basketSuplement);
        }

        public async Task<BasketSuplement> GetBasketSuplementByIdAsync(Guid basketId, Guid suplementId)
        {
            return await context.BasketSuplement.Include(b => b.Suplement).FirstOrDefaultAsync(b => b.BasketId == basketId && b.SuplementId == suplementId);
        }

        public async Task<List<BasketSuplement>> GetSuplementsAsync(Guid? basketId = null)
        {
            return await context.BasketSuplement.Include(b => b.Suplement).Where(b => (basketId == null || b.BasketId == basketId)).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
