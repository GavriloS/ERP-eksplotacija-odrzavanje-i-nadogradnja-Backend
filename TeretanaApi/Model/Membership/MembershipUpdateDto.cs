namespace TeretanaApi.Model.Membership
{
    public class MembershipUpdateDto
    {
        public Guid MembershipId { get; set; }
        public DateTime DateTimeOfPayment { get; set; }
        public Guid UserId { get; set; }
        public Guid MembershipTypeId { get; set; }
    }
}
