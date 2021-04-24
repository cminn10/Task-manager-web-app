using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController: ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllTasks()
        {
            var tasks = await _taskService.ListAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskDetails(id);
            return Ok(task);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTask(TaskRequestModel taskRequest)
        {
            var createdTask = await _taskService.CreateTask(taskRequest);
            return Ok(createdTask);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateTask(TaskRequestModel taskRequest)
        {
            var updatedTask = await _taskService.UpdateTask(taskRequest);
            return Ok(updatedTask);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }

        [HttpPost]
        [Route("complete/{id:int}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var complete = await _taskService.CompleteTask(id);
            return Ok(complete);
        }
    }
}