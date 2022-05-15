using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class UserType
    {
        [Key]
        public Guid UserTypeId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
