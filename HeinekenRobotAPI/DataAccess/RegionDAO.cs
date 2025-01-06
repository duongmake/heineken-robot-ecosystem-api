using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRegionDAO : IBaseDAO<Region, Guid> { }
    public class RegionDAO : BaseDAO<Region, Guid>, IRegionDAO
    {
    }
}
