using System.ComponentModel.DataAnnotations;

namespace TeretanaApi.Entities
{
    public class Membership
    {
        [Key]
        public Guid MembershipId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfPayment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; } 
    }
}
