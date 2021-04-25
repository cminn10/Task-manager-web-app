using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController: ControllerBase
    {
        private readonly ITaskHistoryService _historyService;

        public HistoryController(ITaskHistoryService historyService)
        {
            _historyService = historyService;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListAllHistories()
        {
            var histories = await _historyService.ListAllTaskHistories();
            return Ok(histories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetHistoryById(int id)
        {
            var history = await _historyService.GetHistoryDetails(id);
            return Ok(history);
        }
        
        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<IActionResult> GetHistoriesByUser(int id)
        {
            var tasks = await _historyService.GetHistoriesByUser(id);
            return Ok(tasks);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateHistory(TaskRequestModel taskRequest)
        {
            var createdHistory = await _historyService.CreateTaskHistory(taskRequest);
            return Ok(createdHistory);
        }

        [HttpGet]
        [Route("revert/{id:int}")]
        public async Task<IActionResult> RevertHistory(int id)
        {
            var revertedTask = await _historyService.UpdateTaskHistory(id);
            return Ok(revertedTask);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _historyService.DeleteTaskHistory(id);
            return Ok();
        }
        
    }
}