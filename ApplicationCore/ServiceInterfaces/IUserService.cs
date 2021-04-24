using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<UserResponseModel> GetUserById(int id);
        Task<UserResponseModel> CreateUser(UserRegisterModel registerModel);
        Task<bool> UserExists(string email);
        Task<UserResponseModel> ValidateUser(string email, string password);
        Task<UserResponseModel> UpdateUser(UserUpdateModel updateModel);
        Task DeleteUser(int id);
    }
}