using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IUserDAO : IBaseDAO<User, Guid> { }
    public class UserDAO : BaseDAO<User, Guid>, IUserDAO
    {

    }
}
