using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IGiftRedemptionDAO : IBaseDAO<GiftRedemption, Guid> { }
    public class GiftRedemptionDAO : BaseDAO<GiftRedemption, Guid>, IGiftRedemptionDAO
    {
    }
}
