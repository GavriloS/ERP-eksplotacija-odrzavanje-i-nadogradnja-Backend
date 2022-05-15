using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IBasketEquipmentRepository
    {
        Task<List<BasketEquipment>> GetEqupmentsAsync(Guid? basketId = null);
        Task<BasketEquipment> GetBasketEquipmentByIdAsync(Guid basketId,Guid equipmentId);
        Task<BasketEquipment> CreateBasketEquipmentAsync(BasketEquipment basketEquipment);
        Task SaveChangesAsync();
        Task DeleteBasketEquipmentById(Guid basketId, Guid equipmentId);
    }
}
