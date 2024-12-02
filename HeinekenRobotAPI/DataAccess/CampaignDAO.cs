using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface ICampaignDAO : IBaseDAO<Campaign, Guid> { }
    public class CampaignDAO : BaseDAO<Campaign, Guid>, ICampaignDAO
    {
    }
}
