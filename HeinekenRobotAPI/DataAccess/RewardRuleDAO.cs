using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRewardRuleDAO : IBaseDAO<RewardRule, Guid> { }
    public class RewardRuleDAO : BaseDAO<RewardRule, Guid>, IRewardRuleDAO
    {
    }
}
