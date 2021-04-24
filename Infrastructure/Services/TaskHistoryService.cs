using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class TaskHistoryService: ITaskHistoryService
    {
        private readonly IAsyncRepository<TaskHistory> _taskHistoryRepository;
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;

        public TaskHistoryService(IMapper mapper, IAsyncRepository<TaskHistory> taskHistoryRepository, ITaskService taskService)
        {
            _mapper = mapper;
            _taskHistoryRepository = taskHistoryRepository;
            _taskService = taskService;
        }

        public async Task<IEnumerable<TaskResponseModel>> ListAllTaskHistories()
        {
            var histories = await _taskHistoryRepository.ListAllAsync();
            var response = _mapper.Map<IEnumerable<TaskResponseModel>>(histories);
            return response;
        }

        public async Task<TaskResponseModel> GetHistoryDetails(int id)
        {
            var history = await _taskHistoryRepository.GetByIdWithIncludeAsync(
                h => h.TaskId == id,
                h=>h.User);
            var userModel = _mapper.Map<UserResponseModel>(history.User);
            var response = _mapper.Map<TaskResponseModel>(history);
            response.User = userModel;
            return response;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetHistoriesByUser(int userId)
        {
            var histories = await _taskHistoryRepository.ListAllWithFilterAsync(
                h => h.UserId == userId);
            var response = _mapper.Map<IEnumerable<TaskResponseModel>>(histories);
            return response;
        }

        public async Task<TaskResponseModel> CreateTaskHistory(TaskRequestModel taskRequest)
        {
            var history = _mapper.Map<TaskHistory>(taskRequest);
            var createdHistory = await _taskHistoryRepository.AddAsync(history);
            var response = _mapper.Map<TaskResponseModel>(createdHistory);
            return response;
        }

        //Update history -- revert to be incomplete condition
        public async Task<TaskResponseModel> UpdateTaskHistory(int id, char priority = 'E')
        {
            var history = await _taskHistoryRepository.GetByIdAsync(id);
            var taskRequest = _mapper.Map<TaskRequestModel>(history);
            taskRequest.Id = null;
            taskRequest.Priority = priority;
            var response = await _taskService.CreateTask(taskRequest);
            await this.DeleteTaskHistory(id);
            return response;
        }

        public async Task DeleteTaskHistory(int id)
        {
            var task = await _taskHistoryRepository.GetByIdAsync(id);
            await _taskHistoryRepository.DeleteAsync(task);
        }
    }
}