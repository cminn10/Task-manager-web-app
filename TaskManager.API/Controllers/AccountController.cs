using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterModel registerModel)
        {
            if (await _userService.UserExists(registerModel.Email)) return BadRequest("Username is taken");
            var createdUser = await _userService.CreateUser(registerModel);
            return Ok(createdUser);
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel loginModel)
        {
            var user = await _userService.ValidateUser(loginModel.Email, loginModel.Password);
            if (user == null) return Unauthorized(("Invalid username/password"));

            var jwtToken = _jwtService.CreateToken(user);
            return Ok(new
            {
                token = jwtToken
            });
        }
        
        [Authorize]
        [HttpPost]
        [Route("edit-profile")]
        public async Task<IActionResult> UpdateUser(UserUpdateModel model)
        {
            var user = await _userService.UpdateUser(model);
            return Ok(user);
        }

        [Authorize]
        [HttpDelete("close-account/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}