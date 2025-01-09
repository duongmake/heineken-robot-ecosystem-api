using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RewardRuleRepository : IRewardRuleRepository
    {
        private readonly IRewardRuleDAO _ruleDao;
        public RewardRuleRepository()
        {
            _ruleDao = new RewardRuleDAO();
        }

        public async Task CreateRewardRule(RewardRule rule)
        {
            try
            {
                await _ruleDao.Add(rule);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<RewardRule> GetAllRewardRule()
        {
            try
            {
                var rules = _ruleDao.GetAll().Include(s => s.Campaign)
                                                      .Include(s => s.Gift);
                if (rules != null)
                {
                    return rules;
                }
                throw new Exception("RewardRule not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<RewardRule> GetRewardRuleByID(Guid id)
        {
            try
            {
                return _ruleDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveRewardRule(Guid id)
        {
            try
            {
                return await _ruleDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRewardRule(RewardRuleUpdateDTO rule, Guid id)
        {
            try
            {
                var existRule = await _ruleDao.GetByID(id);
                if (existRule != null)
                {
                    if (rule.PointRangeMin.HasValue)
                    {
                        existRule.PointRangeMin = rule.PointRangeMin.Value;
                    }
                    if (rule.PointRangeMax.HasValue)
                    {
                        existRule.PointRangeMax = rule.PointRangeMax.Value;
                    }
                    if (rule.GiftChance.HasValue)
                    {
                        existRule.GiftChance = rule.GiftChance.Value;
                    }
                    if (rule.CreateTime.HasValue)
                    {
                        existRule.CreateTime = rule.CreateTime.Value;
                    }
                    if (rule.CampaignId.HasValue)
                    {
                        existRule.CampaignId = rule.CampaignId.Value;
                    }
                    if (rule.GiftId.HasValue)
                    {
                        existRule.GiftId = rule.GiftId.Value;
                    }


                    await _ruleDao.Update(existRule);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
