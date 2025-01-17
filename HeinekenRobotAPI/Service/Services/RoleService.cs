using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        public RoleService(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public Task CreateRole(Role role) => _roleRepo.CreateRole(role);

        public IQueryable<Role> GetAllRole() => _roleRepo.GetAllRole();

        public Task<Role> GetRoleByID(Guid id) => _roleRepo.GetRoleByID(id);

        public Task<bool> RemoveRole(Guid id) => _roleRepo.RemoveRole(id);

        public Task UpdateRole(RoleUpdateDTO role, Guid id) => _roleRepo.UpdateRole(role, id);

    }
}
