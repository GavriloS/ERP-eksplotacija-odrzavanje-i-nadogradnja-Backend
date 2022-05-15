namespace TeretanaApi.Model.BasketEquipment
{
    public class BasketEquipmentCreationDto
    {
        public Guid BasketId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
