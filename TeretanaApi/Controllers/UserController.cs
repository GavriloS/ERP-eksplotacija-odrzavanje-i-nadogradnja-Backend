using TeretanaApi.Data.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Model.User;
using TeretanaApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Produces("application/json")]
    public class UserController
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public UserController(IUserRepository userRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,User,Trainer")]
        public async Task<ActionResult<List<UserBasicDto>>> GetUsers()
        {
            var users = await userRepository.GetUsersAsync();
            if(users == null|| users.Count == 0)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(mapper.Map<List<UserBasicDto>>(users));
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Admin,User,Trainer")]
        public async Task<ActionResult<UserBasicDto>> GetUserById(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(mapper.Map<UserBasicDto>(user));
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<UserBasicDto>> CreateUser(UserCreationDto user)
        {
            try
            {
                var newUser = await userRepository.CreateUserAsync(mapper.Map<User>(user));
                await userRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetUserById", "User", new { userId = newUser.UserId });
                return new CreatedResult(location, mapper.Map<UserBasicDto>(newUser));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User,Trainer")]
        public async Task<ActionResult> DeleteUserById(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                return new NotFoundResult();
            }
            try
            {
                await userRepository.DeleteUserByIdAsync(userId);
                await userRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles ="Admin,User,Trainer")]
        public async Task<ActionResult<UserBasicDto>> UpdateUser(UpdateUserDto user)
        {
            var oldUser = await userRepository.GetUserByIdAsync(user.UserId);
            if(oldUser == null)
            {
                return new NotFoundResult();
            }
            try
            {
                mapper.Map(user, oldUser);
                await userRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<UserDto>(oldUser));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
