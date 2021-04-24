using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IJwtService
    {
        string CreateToken(UserResponseModel model);
    }
}