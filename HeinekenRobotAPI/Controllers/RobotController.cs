using AutoMapper;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;
        private readonly IMapper _mapper;
        public RobotController(IRobotService robotService, IMapper mapper)
        {
            _robotService = robotService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRobot()
        {
            try
            {
                var robots = await _robotService.GetAllRobot().ToListAsync();

                if (robots == null || !robots.Any())
                {
                    return NotFound(new
                    {
                        message = "Robot not found."
                    });
                }

                var response = _mapper.Map<List<RobotVM>>(robots);

                return Ok(robots);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
