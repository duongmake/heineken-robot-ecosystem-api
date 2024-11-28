using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUser();
        Task<User> GetUserByID(Guid id);
        Task CreateUser(User robot);
        Task UpdateUser(UserUpdateDTO user, Guid id);
        Task<bool> RemoveUser(Guid id);
    }
}
