using TeretanaApi.Model.Product;

namespace TeretanaApi.Model.Equipment
{
    public class EquipmentsDto
    {
        public List<ProductDto> Equipments { get; set; } = new List<ProductDto>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
