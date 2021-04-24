using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using AutoMapper;

namespace Infrastructure.Helpers
{
    public class TaskManagerMappingProfile: Profile
    {
        public TaskManagerMappingProfile()
        {
            CreateMap<AppUser, UserResponseModel>().ReverseMap();
        }
    }
}