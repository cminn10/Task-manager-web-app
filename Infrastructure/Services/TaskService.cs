using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class TaskService: ITaskService
    {
        public Task<IEnumerable<TaskResponseModel>> ListAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> GetTaskDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TaskResponseModel>> GetTasksByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> CreateTask(TaskRequestModel taskRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> UpdateTask(TaskRequestModel taskRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TaskResponseModel> CompleteTask(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}