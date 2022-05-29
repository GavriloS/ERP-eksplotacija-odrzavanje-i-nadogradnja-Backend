namespace TeretanaApi.Model.Equipment
{
    public class EquipmentBasicDto
    {
        public Guid EquipmentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public TeretanaApi.Entities.EquipmentType EquipmentType { get; set; }
    }
}
