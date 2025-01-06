using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRobotTypeDAO : IBaseDAO<RobotType, Guid> { }
    public class RobotTypeDAO : BaseDAO<RobotType, Guid>, IRobotTypeDAO
    {
    }
}
