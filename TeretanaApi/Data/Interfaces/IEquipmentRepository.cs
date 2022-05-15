using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetEquipmentsAsync(int page,int numOfPageResults,string name = null);
        Task<Equipment> GetEquipmentByIdAsync(Guid equipmentId);
        Task DeleteEquipmentById(Guid equipmentId);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<int> GetEquipmentCountAsync();
        Task SaveChangesAsync();
    }
}
