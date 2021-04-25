using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICryptoService _encryptionService;

        public UserService(IUserRepository userRepository, IMapper mapper, ICryptoService encryptionService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encryptionService = encryptionService;
        }


        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var result = _mapper.Map<IEnumerable<UserResponseModel>>(users);
            return result;
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var tasks = _mapper.Map<IEnumerable<TaskResponseModel>>(user.Tasks);
            var histories = _mapper.Map<IEnumerable<TaskResponseModel>>(user.TasksHistories);
            var userModel = _mapper.Map<UserResponseModel>(user);
            userModel.Tasks = tasks;
            userModel.TasksHistories = histories;
            return userModel;
        }

        public async Task<UserResponseModel> CreateUser(UserRegisterModel registerModel)
        {
            //var encryption = _encryptionService.GetEncryption(registerModel.Password);
            var user = new AppUser()
            {
                Email = registerModel.Email.ToLower(),
                Mobileno = registerModel.Mobileno,
                Fullname = registerModel.Fullname,
                Password = _encryptionService.HashPassword(registerModel.Password),
                // PasswordHash = encryption[0],
                // PasswordSalt = encryption[1]
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = _mapper.Map<UserResponseModel>(createdUser);
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _userRepository.UserExists(email);
        }

        public async Task<UserResponseModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null;
            
            bool isSuccess = true;
            
            //var passwordHash = _encryptionService.GetEncryption(password, user.PasswordSalt)[0];
            // for (int i = 0; i < passwordHash.Length; i++)
            // {
            //     if (passwordHash[i] != user.PasswordHash[i]) isSuccess = false;
            // }
            
            var passwordHash = _encryptionService.HashPassword(password);
            isSuccess = user.Password == passwordHash;
            var response = _mapper.Map<UserResponseModel>(user);
            return isSuccess ? response : null; 
        }
        
        public async Task<UserResponseModel> UpdateUser(UserUpdateModel model)
        {
            var updateUser = _mapper.Map<AppUser>(model);
            var updatedUser = await _userRepository.UpdateAsync(updateUser, 
                u=>u.Email, u=>u.Fullname, u=>u.Mobileno);
            var result = _mapper.Map<UserResponseModel>(updatedUser);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }
    }
}