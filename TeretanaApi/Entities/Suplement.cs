using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Suplement
    {
        [Key]
        public Guid SuplementId { get; set; } = Guid.NewGuid();

        public String Name { get; set; }
        public String Description { get; set; }
        public String Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public Guid SuplementTypeId { get; set; }
        public SuplementType SuplementType { get; set; }

    }
}
