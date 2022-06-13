using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetEquipmentsAsync(int page,int numOfPageResults,string name = null, string sortOrder = "",Guid? typeId = null);
        Task<List<Equipment>> GetEquipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(Guid equipmentId);
        Task DeleteEquipmentById(Guid equipmentId);
        Task<Equipment> GetEquipmentByPriceIdAsync(string priceId);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<int> GetEquipmentCountAsync();
        Task SaveChangesAsync();
    }
}
