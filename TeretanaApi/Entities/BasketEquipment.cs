namespace TeretanaApi.Entities
{
    public class BasketEquipment
    {
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int Quantity { get; set; }
    }
}
