using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task CreateUser(User robot) => _userRepo.CreateUser(robot);

        public IQueryable<User> GetAllUser() => _userRepo.GetAllUser();

        public Task<User> GetUserByID(Guid id) => _userRepo.GetUserByID(id);

        public Task<bool> RemoveUser(Guid id) => _userRepo.RemoveUser(id);

        public Task UpdateUser(UserUpdateDTO user, Guid id) => _userRepo.UpdateUser(user, id);

    }
}
