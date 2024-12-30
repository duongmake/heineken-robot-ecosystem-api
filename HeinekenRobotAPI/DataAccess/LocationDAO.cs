using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface ILocationDAO : IBaseDAO<Location, Guid> { }
    public class LocationDAO : BaseDAO<Location, Guid>, ILocationDAO
    {
    }
}
