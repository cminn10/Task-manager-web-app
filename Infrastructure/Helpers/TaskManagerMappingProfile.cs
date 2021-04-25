using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;

namespace Infrastructure.Helpers
{
    public class TaskManagerMappingProfile: Profile
    {
        public TaskManagerMappingProfile()
        {
            CreateMap<AppUser, UserResponseModel>()
                .ForMember(x=>x.Tasks, opt=>opt.Ignore())
                .ForMember(x=>x.TasksHistories, opt=>opt.Ignore())
                .ReverseMap();
            CreateMap<UserRegisterModel, AppUser>();
            CreateMap<UserUpdateModel, AppUser>();
            
            CreateMap<AppTask, TaskResponseModel>()
                .ForMember(x=>x.User, opt=>opt.Ignore())
                .ReverseMap();
            CreateMap<TaskRequestModel, AppTask>().ReverseMap();
            
            CreateMap<TaskHistory, TaskResponseModel>()
                .ForMember(x=>x.Id, opt=>opt.MapFrom(m=>m.TaskId))
                .ForMember(x=>x.User, opt=>opt.Ignore())
                .ReverseMap();
            CreateMap<TaskRequestModel, TaskHistory>()
                .ForMember(x=>x.TaskId, opt=>opt.MapFrom(m=>m.Id))
                .ReverseMap();
        }
    }
}