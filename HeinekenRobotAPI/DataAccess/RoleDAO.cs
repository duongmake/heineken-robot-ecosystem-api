using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRoleDAO : IBaseDAO<Role, Guid> { }
    public class RoleDAO : BaseDAO<Role, Guid>, IRoleDAO
    {
    }
}
