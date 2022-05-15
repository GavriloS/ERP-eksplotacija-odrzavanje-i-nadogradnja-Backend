namespace TeretanaApi.Model.User
{
    public class UpdateUserDto
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public int? NumberOfTrainings { get; set; } = 0;
        public int? NumberOfGroupTraings { get; set; } = 0;
        public Guid AddressId { get; set; }
        public Guid UserTypeId { get; set; }

    }
}
