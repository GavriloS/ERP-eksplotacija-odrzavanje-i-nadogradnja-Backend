using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IEquipmentTypeRepository
    {
        public Task<List<EquipmentType>> GetEquipmentTypesAsync();
        public Task<EquipmentType> GetEquipmentTypeByIdAsync(Guid equipmentTypeId);
        public Task DeleteEquipmentTypeByIdAsync(Guid equipmentTypeId);
        public Task<EquipmentType> CreateEquipmentTypeAsync(EquipmentType equipmentType);
        public Task SaveChangesAsync();
    }
}
