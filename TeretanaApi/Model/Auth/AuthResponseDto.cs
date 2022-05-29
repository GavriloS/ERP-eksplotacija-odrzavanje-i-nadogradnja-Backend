using TeretanaApi.Model.User;

namespace TeretanaApi.Model.Auth
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public UserBasicDto User { get; set; }
        public int ExpiresIn { get; set; }
    }
}
