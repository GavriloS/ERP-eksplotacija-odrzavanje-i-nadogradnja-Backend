namespace TeretanaApi.Model.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int? NumberOfTrainings { get; set; } = 0;
        public int? NumberOfGroupTraings { get; set; } = 0;
        public TeretanaApi.Entities.Address Address { get; set; }

        public TeretanaApi.Entities.UserType UserType { get; set; }
    }
}
