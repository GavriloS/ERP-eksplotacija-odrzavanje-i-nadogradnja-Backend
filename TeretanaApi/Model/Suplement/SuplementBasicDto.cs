namespace TeretanaApi.Model.Suplement
{
    public class SuplementBasicDto
    {
        public Guid SuplementId { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public String Manufacturer { get; set; }
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public double Price { get; set; }
        public TeretanaApi.Entities.SuplementType SuplementType { get; set; }
    }
}
