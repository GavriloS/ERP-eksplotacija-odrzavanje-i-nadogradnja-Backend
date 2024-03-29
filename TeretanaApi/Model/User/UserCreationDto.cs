﻿namespace TeretanaApi.Model.User
{
    public class UserCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserTypeId { get; set; }
    }
}
