namespace TeretanaApi.Model.MembershipType
{
    public class MembershipTypeCreationDto
    {
        public string Name { get; set; }
        public int NumberOfTrainings { get; set; }
        public int NumberOfGroupTrainings { get; set; }
        public double Price { get; set; }
    }
}
