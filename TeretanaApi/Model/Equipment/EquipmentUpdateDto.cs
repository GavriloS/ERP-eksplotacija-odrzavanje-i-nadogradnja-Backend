namespace TeretanaApi.Model.Equipment
{
    public class EquipmentUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public Guid TypeId { get; set; }
    }
}
