using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Auth;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.User;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController
    {
        private readonly JwtAuthManager jwtAuthManager;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public AuthController(JwtAuthManager jwtAuthManager,IUserRepository userRepository,IMapper mapper)
        {
            this.jwtAuthManager = jwtAuthManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreationDto userCreationDto)
        {
            jwtAuthManager.CreatePasswordHash(userCreationDto.Password,out byte[] passwordHash,out byte[] passwordSalt);
            var user = mapper.Map<User>(userCreationDto);

            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;

            await userRepository.CreateUserAsync(user);
            await userRepository.SaveChangesAsync();
            return new OkObjectResult(mapper.Map<UserDto>(user));
            
        }
        

        [HttpPost("authorize")]
        public async Task<IActionResult> Authorize(UserAuthDto request)
        {
            var user = await userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return new NotFoundResult();
            }
            else if (!jwtAuthManager.VerifyPasswordHash(request.Password,user.Password,user.PasswordSalt))
            {
                return new BadRequestObjectResult("Pogrešna lozinka");
            }
            string userType = user.UserType.Name;

            var token = jwtAuthManager.Authenticate(request.Email, request.Password, userType);
            if (token == null)
            {
                return new UnauthorizedResult();
            }



            return new OkObjectResult(token);
        }
    }
}
