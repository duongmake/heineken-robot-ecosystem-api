using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleDAO _roleDao;
        public RoleRepository()
        {
            _roleDao = new RoleDAO();
        }

        public async Task CreateRole(Role role)
        {
            try
            {
                await _roleDao.Add(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Role> GetAllRole()
        {
            try
            {
                var roles = _roleDao.GetAll();
                if (roles != null)
                {
                    return roles;
                }
                throw new Exception("Role not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Role> GetRoleByID(Guid id)
        {
            try
            {
                return _roleDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveRole(Guid id)
        {
            try
            {
                return await _roleDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRole(RoleUpdateDTO role, Guid id)
        {
            try
            {
                var existRole = await _roleDao.GetByID(id);
                if (existRole != null)
                {
                    if (!string.IsNullOrEmpty(role.RoleName))
                    {
                        existRole.RoleName = role.RoleName;
                    }

                    await _roleDao.Update(existRole);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
