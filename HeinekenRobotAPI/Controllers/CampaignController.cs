using AutoMapper;
using HeinekenRobotAPI.DTO.ViewModels;
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

                var response = _mapper.Map<List<RobotVM>>(campains);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
