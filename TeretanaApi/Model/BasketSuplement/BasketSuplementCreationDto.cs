namespace TeretanaApi.Model.BasketSuplement
{
    public class BasketSuplementCreationDto
    {
        public Guid BasketId { get; set; }
        public Guid SuplementId { get; set; }
        public int Quantity { get; set; }
    }
}
