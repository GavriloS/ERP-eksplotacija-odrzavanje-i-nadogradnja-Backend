namespace TeretanaApi.Model.BasketEquipment
{
    public class BasketEquipmentUpdateDto
    {
        public Guid BasketId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
