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
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;
        public CampaignController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCampaign()
        {
            try
            {
                var campains = await _campaignService.GetAllCampaign().ToListAsync();

                if (campains == null || !campains.Any())
                {
                    return NotFound(new
                    {
                        message = "Campaign not found."
                    });
                }

                var response = _mapper.Map<List<CampaignVM>>(campains);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignByID(Guid id)
        {
            var campaign = await _campaignService.GetCampaignByID(id);

            if (campaign != null)
            {
                var responese = _mapper.Map<CampaignVM>(campaign);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Campaign không tồn tại."
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignCreateDTO campaign)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newAccount = new CampaignCreateDTO
                {
                    CampaignId = Guid.NewGuid(),
                    CampaignName = campaign.CampaignName,
                    Description = campaign.Description,
                    StartDate = campaign.StartDate,
                    EndDate = campaign.EndDate,
                    Status = campaign.Status,
                    RegionId = campaign.RegionId
                };
                var _campaign = _mapper.Map<Campaign>(newAccount);

                await _campaignService.CreateCampaign(_campaign);
                return Ok(new
                {
                    message = "Tạo Campaign thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCampaign([FromForm] CampaignUpdateDTO campaign, Guid id)
        {
            try
            {
                var existingCampaign = _campaignService.GetCampaignByID(id);
                if (existingCampaign != null)
                {
                    await _campaignService.UpdateCampaign(campaign, id);

                    return Ok(new
                    {
                        message = "Cập nhật Campaign thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Campaign không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCampaign(Guid id)
        {
            try
            {
                var existingCampaign = await _campaignService.GetCampaignByID(id);
                if (existingCampaign != null)
                {
                    var result = await _campaignService.RemoveCampaign(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Campaign thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Campaign không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Robot không tồn tại."
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