using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseModel>> ListAllTasks();
        Task<TaskResponseModel> GetTaskDetails(int id);
        Task<IEnumerable<TaskResponseModel>> GetTasksByUser(int userId);

        Task<TaskResponseModel> CreateTask(TaskRequestModel taskRequest);
        Task<TaskResponseModel> UpdateTask(TaskRequestModel taskRequest);
        Task DeleteTask(int id);

        Task<TaskResponseModel> CompleteTask(int id);
    }
}