using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data 
{ 
    public class BasketEquipmentRepository : IBasketEquipmentRepository
    {
         private readonly GymContext context;

        public BasketEquipmentRepository(GymContext context)
        {
            this.context = context;
        }
        public async Task<BasketEquipment> CreateBasketEquipmentAsync(BasketEquipment basketEquipment)
        {
            await context.BasketEquipment.AddAsync(basketEquipment);
            return basketEquipment;
        }

        public async Task DeleteBasketEquipmentById(Guid basketId, Guid equipmentId)
        {
            var basketEquipment = await GetBasketEquipmentByIdAsync(basketId,equipmentId);
            context.BasketEquipment.Remove(basketEquipment);
        }

        public async Task<BasketEquipment> GetBasketEquipmentByIdAsync(Guid basketId, Guid equipmentId)
        {
            return await context.BasketEquipment.Include(b => b.Equipment).FirstOrDefaultAsync(b => b.BasketId == basketId && b.EquipmentId == equipmentId);
        }

        public async Task<List<BasketEquipment>> GetEqupmentsAsync(Guid? basketId = null)
        {
            return await context.BasketEquipment.Include(b => b.Equipment).Where(b => (basketId == null || b.BasketId == basketId)).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
