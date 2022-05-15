using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Basket
    {
        [Key]
        public Guid BasketId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfPurchase { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsCompleted { get; set; }

        public virtual List<BasketEquipment> Equipments { get; set; }
        public virtual List<BasketSuplement> Suplements { get; set; }
    }
}
