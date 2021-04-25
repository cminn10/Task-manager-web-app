using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository: EfRepository<AppUser>, IUserRepository
    {
        public UserRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<AppUser> GetByIdAsync(int id)
        {
            var user = _dbContext.Users
                .Include(u => u.Tasks)
                .Include(u=>u.TasksHistories)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email.ToLower());
        }
    }
}