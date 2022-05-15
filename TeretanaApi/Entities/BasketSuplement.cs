namespace TeretanaApi.Entities
{
    public class BasketSuplement
    {
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid SuplementId { get; set; }
        public Suplement Suplement { get; set; }
       
        public int Quantity { get; set; }
    }
}
