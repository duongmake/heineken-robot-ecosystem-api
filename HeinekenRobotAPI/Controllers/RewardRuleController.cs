using AutoMapper;
using HeinekenRobotAPI.DTO.Create;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Service.IServices;
using HeinekenRobotAPI.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardRuleController : ControllerBase
    {
        private readonly IRewardRuleService _ruleService;
        private readonly IMapper _mapper;
        public RewardRuleController(IRewardRuleService ruleService, IMapper mapper)
        {
            _ruleService = ruleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRewardRule()
        {
            try
            {
                var rules = await _ruleService.GetAllRewardRule().ToListAsync();

                if (rules == null || !rules.Any())
                {
                    return NotFound(new
                    {
                        message = "RewardRule not found."
                    });
                }

                var response = _mapper.Map<List<RewardRuleVM>>(rules);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRewardRuleByID(Guid id)
        {
            var rule = await _ruleService.GetRewardRuleByID(id);

            if (rule != null)
            {
                var responese = _mapper.Map<RewardRuleVM>(rule);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "RewardRule không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateRewardRule([FromBody] RewardRuleCreateDTO rule)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newRule = new RewardRuleCreateDTO
                {
                    RewardRuleId = Guid.NewGuid(),
                    PointRangeMin = rule.PointRangeMin,
                    PointRangeMax = rule.PointRangeMax,
                    GiftChance = rule.GiftChance,
                    CreateTime = rule.CreateTime,
                    CampaignId = rule.CampaignId,
                    GiftId = rule.GiftId
                };
                var _rule = _mapper.Map<RewardRule>(newRule);

                await _ruleService.CreateRewardRule(_rule);
                return Ok(new
                {
                    message = "Tạo RewardRule thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRewardRule([FromForm] RewardRuleUpdateDTO rule, Guid id)
        {
            try
            {
                var existingRule = _ruleService.GetRewardRuleByID(id);
                if (existingRule != null)
                {
                    await _ruleService.UpdateRewardRule(rule, id);

                    return Ok(new
                    {
                        message = "Cập nhật RewardRule thành công."
                    });

                }

                return NotFound(new
                {
                    message = "RewardRule không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRewardRule(Guid id)
        {
            try
            {
                var existingRule = await _ruleService.GetRewardRuleByID(id);
                if (existingRule != null)
                {
                    var result = await _ruleService.RemoveRewardRule(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa RewardRule thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "RewardRule không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "RewardRule không tồn tại."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }


    }
}
