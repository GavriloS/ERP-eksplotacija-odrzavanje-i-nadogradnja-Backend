using TeretanaApi.Model.BasketEquipment;
using TeretanaApi.Model.BasketSuplement;
using TeretanaApi.Model.User;

namespace TeretanaApi.Model.Basket
{
    public class BasketDto
    {
        public Guid BasketId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfPurchase { get; set; }
        public UserBasicDto User { get; set; }
        public bool IsCompleted { get; set; }

        public virtual List<BasketEquipmentDto> Equipments { get; set; }
        public virtual List<BasketSuplementDto> Suplements { get; set; }
    }
}
