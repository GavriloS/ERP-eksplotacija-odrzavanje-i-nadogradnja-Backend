using TeretanaApi.Entities;

namespace TeretanaApi.Data.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAddressesAsync();
        Task<Address> GetAddressByIdAsync(Guid addressId);
        Task DeleteAddressByIdAsync(Guid addressId);
        Task<Address> CreateAddressAsync(Address address);
        Task SaveChangesAsync();
    }
}
