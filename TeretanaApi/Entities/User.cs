using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? NumberOfTrainings { get; set; } = 0;
        public int? NumberOfGroupTraings { get; set; } = 0;
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public virtual List<GroupTraining> GroupTrainings { get; set; }
    }
}
