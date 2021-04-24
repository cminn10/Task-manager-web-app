using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class TaskHistoryService: ITaskHistoryService
    {
        public Task<IEnumerable<TaskResponseModel>> ListAllTaskHistories()
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> GetHistoryDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TaskResponseModel>> GetHistoryByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> CreateTaskHistory(TaskRequestModel taskRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> UpdateTaskHistory(TaskRequestModel taskRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTaskHistory(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}