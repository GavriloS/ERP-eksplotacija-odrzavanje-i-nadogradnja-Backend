using TeretanaApi.Model.Product;

namespace TeretanaApi.Model.Suplement
{
    public class SuplementsDto
    {
        public List<ProductDto> Suplements { get; set; } = new List<ProductDto>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
