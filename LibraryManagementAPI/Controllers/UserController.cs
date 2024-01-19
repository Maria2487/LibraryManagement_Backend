using LibraryManagement.Application.DTOs.Account;
using LibraryManagement.Application.DTOs.User;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await userService.GetAll();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await userService.GetById(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            var user = await userService.Create(userDto);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto userDtor)
        {
            var user = await userService.Update(id, userDtor);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await userService.Delete(id);

            return Ok();
        }

        //Authentification
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var user = await userService.Login(loginDto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
