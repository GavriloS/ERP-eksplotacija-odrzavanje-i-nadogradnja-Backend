using TeretanaApi.Model.Equipment;

namespace TeretanaApi.Model.BasketEquipment
{
    public class BasketEquipmentDto
    {
        public Guid BasketId { get; set; }
        public EquipmentBasicDto Equipment { get; set; }
        public int Quantity { get; set; }
    }
}
