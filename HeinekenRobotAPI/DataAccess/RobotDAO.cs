using HeinekenRobotAPI.Data;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRobotDAO : IBaseDAO<Robot, Guid> { }
    public class RobotDAO : BaseDAO<Robot, Guid>, IRobotDAO
    {

    }
}
