using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository: IAsyncRepository<AppUser>
    {
        Task<AppUser> GetUserByEmail(string userName);
        Task<bool> UserExists(string userName);
    }
}