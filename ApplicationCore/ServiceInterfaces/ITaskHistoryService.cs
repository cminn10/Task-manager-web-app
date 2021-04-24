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
        Task<IEnumerable<TaskResponseModel>> GetHistoriesByUser(int userId);

        Task<TaskResponseModel> CreateTaskHistory(TaskRequestModel taskRequest);
        Task<TaskResponseModel> UpdateTaskHistory(int id, char priority = 'E');
        Task DeleteTaskHistory(int id);
    }
}