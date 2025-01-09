using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRewardRuleRepository
    {
        IQueryable<RewardRule> GetAllRewardRule();
        Task<RewardRule> GetRewardRuleByID(Guid id);
        Task CreateRewardRule(RewardRule rule);
        Task UpdateRewardRule(RewardRuleUpdateDTO rule, Guid id);
        Task<bool> RemoveRewardRule(Guid id);
    }
}
