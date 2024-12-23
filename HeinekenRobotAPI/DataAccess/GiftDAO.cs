using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IGiftDAO : IBaseDAO<Gift, Guid> { }
    public class GiftDAO : BaseDAO<Gift, Guid>, IGiftDAO
    {
    }
}
