namespace TeretanaApi.Model.Basket
{
    public class BasketCreationDto
    {
        public DateTime DateTimeOfPurchase { get; set; }
        public Guid UserId { get; set; }
        public bool IsCompleted { get; set; }
  
        public virtual Dictionary<Guid,int> EquipmentIds { get; set; }
        public virtual Dictionary<Guid,int> SuplementIds { get; set; }
    }
}
