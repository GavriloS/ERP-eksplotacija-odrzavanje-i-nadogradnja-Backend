namespace TeretanaApi.Model.Suplement
{
    public class SuplementsDto
    {
        public List<SuplementBasicDto> Suplements { get; set; } = new List<SuplementBasicDto>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
