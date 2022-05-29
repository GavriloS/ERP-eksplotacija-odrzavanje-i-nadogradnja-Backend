namespace TeretanaApi.Model.User
{
    public class UserBasicDto
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int? NumberOfTrainings { get; set; }
        public int? NumberOfGroupTraings { get; set; }
        public TeretanaApi.Entities.UserType UserType { get; set; }
    }
}
