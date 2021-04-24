using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITaskHistoryService
    {
        Task<IEnumerable<TaskResponseModel>> ListAllTaskHistories();
        Task<TaskResponseModel> GetHistoryDetails(int id);
        Task<IEnumerable<TaskResponseModel>> GetHistoryByUser(int userId);

        Task<TaskResponseModel> CreateTaskHistory(TaskRequestModel taskRequest);
        Task<TaskResponseModel> UpdateTaskHistory(TaskRequestModel taskRequest);
        Task DeleteTaskHistory(int id);
    }
}