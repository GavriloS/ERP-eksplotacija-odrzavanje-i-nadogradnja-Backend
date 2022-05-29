using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Equipment
    {
        [Key]
        public Guid EquipmentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public Guid EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
      



    }
}
