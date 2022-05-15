using Microsoft.EntityFrameworkCore;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Entities.DataContext;

namespace TeretanaApi.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly GymContext _context;

        public AddressRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            return address;
        }

        public async Task DeleteAddressByIdAsync(Guid addressId)
        {
            var address = await GetAddressByIdAsync(addressId);
            _context.Addresses.Remove(address);
        }

        public async Task<Address> GetAddressByIdAsync(Guid addressId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == addressId);
        }

        public async Task<List<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
