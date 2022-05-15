using TeretanaApi.Model.User;

namespace TeretanaApi.Model.Membership
{
    public class MembershipDto
    {
        
        public Guid MembershipId { get; set; } = Guid.NewGuid();
        public DateTime DateTimeOfPayment { get; set; }
        public UserBasicDto User { get; set; }
        public TeretanaApi.Entities.MembershipType MembershipType { get; set; }
    }
}
