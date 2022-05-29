using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly GymContext _context;

        public BasketRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<Basket> CreateBasketAsync(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            return basket;
        }

        public async Task DeleteBasketByIdAsync(Guid basketId)
        {
            var basket = await GetBasketByIdAsync(basketId);
            _context.Baskets.Remove(basket);
        }

        public async Task<Basket> GetBasketByIdAsync(Guid basketId)
        {
            return await _context.Baskets.Include(b => b.User).Include(b => b.Suplements).ThenInclude(s => s.Suplement).Include(b => b.Equipments).ThenInclude(e => e.Equipment).FirstOrDefaultAsync(b => b.BasketId == basketId);
        }

        public async Task<List<Basket>> GetBasketsAsync()
        {
            return await _context.Baskets.Include(b => b.User).Include(b => b.Suplements).ThenInclude(s => s.Suplement).Include(b => b.Equipments).ThenInclude(e => e.Equipment).ToListAsync();
        }

        public async Task<List<Basket>> GetBasketsByUser(Guid userId)
        {
            return await _context.Baskets.Include(b => b.User).Include(b => b.Suplements).ThenInclude(s => s.Suplement).Include(b => b.Equipments).ThenInclude(e => e.Equipment).Where(b => b.UserId == userId).ToListAsync();

        }
        public async Task<Basket> GetOpenBasketByUser(Guid userId)
        {
            return await _context.Baskets.Include(b => b.User).Include(b => b.Suplements).ThenInclude(s => s.Suplement).Include(b => b.Equipments).ThenInclude(e => e.Equipment).FirstOrDefaultAsync(b => (b.UserId == userId && b.IsCompleted == false));
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
