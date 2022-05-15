namespace TeretanaApi.Model.Suplement
{
    public class SuplementUpdateDto
    {
        public Guid SuplementId { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public String Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid SuplementTypeId { get; set; }
    }
}
