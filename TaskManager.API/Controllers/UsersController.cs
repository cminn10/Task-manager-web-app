using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:int}/task")]
        public async Task<IActionResult> GetTasksByUser(int userId)
        {
            var tasks = await _taskService.GetTasksByUser(userId);
            return Ok(tasks);
        }
    }
}