using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {

        private readonly GymContext _context;

        public EquipmentTypeRepository(GymContext context)
        {
            _context = context;
        }
        public async Task<EquipmentType> CreateEquipmentTypeAsync(EquipmentType equipmentType)
        {
            await _context.EquipmentTypes.AddAsync(equipmentType);
            return equipmentType;
        }

        public async Task DeleteEquipmentTypeByIdAsync(Guid equipmentTypeId)
        {
            var equipmentType = await GetEquipmentTypeByIdAsync(equipmentTypeId);
            _context.EquipmentTypes.Remove(equipmentType);

        }

        public async Task<EquipmentType> GetEquipmentTypeByIdAsync(Guid equipmentTypeId)
        {
            return await _context.EquipmentTypes.FirstOrDefaultAsync(e => e.EquipmentTypeId == equipmentTypeId);
        }

        public async Task<List<EquipmentType>> GetEquipmentTypesAsync()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
