using TeretanaApi.Model.Suplement;

namespace TeretanaApi.Model.BasketSuplement
{
    public class BasketSuplementDto
    {
        public Guid BasketId { get; set; }
        public SuplementBasicDto Suplement { get; set; }

        public int Quantity { get; set; }
    }
}
