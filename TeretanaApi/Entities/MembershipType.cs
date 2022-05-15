using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class MembershipType
    {
        [Key]
        public Guid MembershipTypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int NumberOfTrainings { get; set; }
        public int NumberOfGroupTrainings { get; set; }
        public double Price { get; set; }

    }
}
