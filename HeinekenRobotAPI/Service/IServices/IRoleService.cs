using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IRoleService
    {
        IQueryable<Role> GetAllRole();
        Task<Role> GetRoleByID(Guid id);
        Task CreateRole(Role role);
        Task UpdateRole(RoleUpdateDTO role, Guid id);
        Task<bool> RemoveRole(Guid id);
    }
}
