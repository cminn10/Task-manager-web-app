using System;
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
    public class TaskService: ITaskService
    {
        private readonly IAsyncRepository<AppTask> _taskRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TaskHistory> _historyRepository;

        public TaskService(IAsyncRepository<AppTask> taskRepository, IMapper mapper, IAsyncRepository<TaskHistory> historyRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _historyRepository = historyRepository;
        }

        public async Task<IEnumerable<TaskResponseModel>> ListAllTasks()
        {
            var tasks = await _taskRepository.ListAllAsync();
            var response = _mapper.Map<IEnumerable<TaskResponseModel>>(tasks);
            return response;
        }

        public async Task<TaskResponseModel> GetTaskDetails(int id)
        {
            var task = await _taskRepository.GetByIdWithIncludeAsync(
                t => t.Id == id, 
                t => t.User);
            var userModel = _mapper.Map<UserResponseModel>(task.User);
            var response = _mapper.Map<TaskResponseModel>(task);
            response.User = userModel;
            return response;
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksByUser(int userId)
        {
            var tasks = await _taskRepository.ListAllWithFilterAsync(
                t => t.UserId == userId);
            var response = _mapper.Map<IEnumerable<TaskResponseModel>>(tasks);
            return response;
        }

        public async Task<TaskResponseModel> CreateTask(TaskRequestModel taskRequest)
        {
            var task = _mapper.Map<AppTask>(taskRequest);
            var createdTask = await _taskRepository.AddAsync(task);
            var response = _mapper.Map<TaskResponseModel>(createdTask);
            return response;
        }

        public async Task<TaskResponseModel> UpdateTask(TaskRequestModel taskRequest)
        {
            var task = _mapper.Map<AppTask>(taskRequest);
            var updatedTask = await _taskRepository.UpdateAsync(task,
                t => t.Title,
                t => t.Description,
                t => t.DueDate,
                t => t.Priority,
                t => t.Remarks);
            var response = _mapper.Map<TaskResponseModel>(updatedTask);
            return response;
        }

        public async Task DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            await _taskRepository.DeleteAsync(task);
        }

        public async Task<TaskResponseModel> CompleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            var historyRequest = _mapper.Map<TaskRequestModel>(task);
            historyRequest.Completed = DateTime.UtcNow.Date;

            var history = _mapper.Map<TaskHistory>(historyRequest);
            var historyCreated = await _historyRepository.AddAsync(history);
            var response = _mapper.Map<TaskResponseModel>(historyCreated);
            await this.DeleteTask(id);
            return response;
        }
    }
}