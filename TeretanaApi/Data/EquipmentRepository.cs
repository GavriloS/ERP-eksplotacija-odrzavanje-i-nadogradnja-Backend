using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly GymContext _context;

        public EquipmentRepository(GymContext context)
        {
            _context = context;
        }
        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            return equipment;
        }

        public async Task DeleteEquipmentById(Guid equipmentId)
        {
            var equpment = await GetEquipmentByIdAsync(equipmentId);
            _context.Equipments.Remove(equpment);
        }

        public Task<Equipment> GetEquipmentByIdAsync(Guid equipmentId)
        {
            return _context.Equipments.Include(et => et.EquipmentType).FirstOrDefaultAsync(e => e.EquipmentId == equipmentId);
        }

        public async Task<List<Equipment>> GetEquipmentsAsync(int page,int numOfPageResults, string name = null, string sortOrder = "",Guid? typeId = null)
        {
            switch (sortOrder)
            {
                case "price_desc":
                    return await _context.Equipments.Include(et => et.EquipmentType).OrderByDescending(e => e.Price).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(e => (name == null || e.Name.Contains(name)) && (typeId == null || e.EquipmentTypeId == typeId)).ToListAsync();

              
                case "price_asc":
                    return await _context.Equipments.Include(et => et.EquipmentType).OrderBy(e => e.Price).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(e => (name == null || e.Name.Contains(name)) && (typeId == null || e.EquipmentTypeId == typeId)).ToListAsync();

              
                default:
                    return await _context.Equipments.Include(et => et.EquipmentType).Skip((page - 1) * numOfPageResults).Take(numOfPageResults).Where(e => (name == null || e.Name.Contains(name)) && (typeId == null || e.EquipmentTypeId == typeId)).ToListAsync();

                
            }
            
           
        
        }
        public async Task<List<Equipment>> GetEquipmentsAsync()
        {
            return await _context.Equipments.Include(et => et.EquipmentType).ToListAsync();
        }

        public async Task<int> GetEquipmentCountAsync()
        {
            return await _context.Equipments.CountAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Equipment> GetEquipmentByPriceIdAsync(string priceId)
        {
            return await _context.Equipments.Include(et => et.EquipmentType).FirstOrDefaultAsync(e => e.PriceId == priceId);
        }
    }
}
