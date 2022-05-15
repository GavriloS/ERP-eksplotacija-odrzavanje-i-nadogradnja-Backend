using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
