namespace TeretanaApi.Model.Suplement
{
    public class SuplementCreationDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid SuplementTypeId { get; set; }
     
    }
}
