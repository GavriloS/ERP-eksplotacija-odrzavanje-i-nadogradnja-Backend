namespace TeretanaApi.Model.Membership
{
    public class MembershipCreationDto
    {
        public DateTime DateTimeOfPayment { get; set; }
        public Guid UserId { get; set; }
        public Guid MembershipTypeId { get; set; }
    }
}
