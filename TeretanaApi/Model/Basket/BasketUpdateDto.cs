namespace TeretanaApi.Model.Basket
{
    public class BasketUpdateDto
    {
        public Guid BasketId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfPurchase { get; set; }
        public bool IsCompleted { get; set; }
    }
}
