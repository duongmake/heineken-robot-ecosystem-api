using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllRole();
        Task<Role> GetRoleByID(Guid id);
        Task CreateRole(Role role);
        Task UpdateRole(RoleUpdateDTO role, Guid id);
        Task<bool> RemoveRole(Guid id);
    }
}
