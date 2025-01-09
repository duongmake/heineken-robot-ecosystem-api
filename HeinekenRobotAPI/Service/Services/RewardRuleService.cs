using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RewardRuleService : IRewardRuleService
    {
        private readonly IRewardRuleRepository _ruleRepo;
        public RewardRuleService(IRewardRuleRepository ruleRepo)
        {
            _ruleRepo = ruleRepo;
        }

        public Task CreateRewardRule(RewardRule rule) => _ruleRepo.CreateRewardRule(rule);

        public IQueryable<RewardRule> GetAllRewardRule() => _ruleRepo.GetAllRewardRule();

        public Task<RewardRule> GetRewardRuleByID(Guid id) => _ruleRepo.GetRewardRuleByID(id);

        public Task<bool> RemoveRewardRule(Guid id) => _ruleRepo.RemoveRewardRule(id);

        public Task UpdateRewardRule(RewardRuleUpdateDTO rule, Guid id) => _ruleRepo.UpdateRewardRule(rule, id);

    }
}
