using AutoMapper;
using HeinekenRobotAPI.DTO.Create;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace HeinekenRobotAPI.Controllers
{
    [Route("api/robots")]
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

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotByID(Guid id)
        {
            var robot = await _robotService.GetRobotByID(id);

            if (robot != null)
            {
                var responese = _mapper.Map<RobotVM>(robot);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Robot không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateRobot([FromBody] RobotCreateDTO robot)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newAccount = new RobotCreateDTO
                {
                    RobotId = Guid.NewGuid(),
                    RobotName = robot.RobotName,
                    Status = robot.Status,
                    BatteryLevel = robot.BatteryLevel,
                    LastAccessTime = robot.LastAccessTime,
                    RobotTypeId = robot.RobotTypeId,
                    LocationId = robot.LocationId
                };
                var _robot = _mapper.Map<Robot>(newAccount);

                await _robotService.CreateRobot(_robot);
                return Ok(new
                {
                    message = "Tạo Robot thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRobot([FromForm] RobotUpdateDTO robot, Guid id)
        {
            try
            {
                var existingRobot = _robotService.GetRobotByID(id);
                if (existingRobot != null)
                {
                    await _robotService.UpdateRobot(robot, id);

                    return Ok(new
                    {
                        message = "Cập nhật Robot thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Tài khoản không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRobot(Guid id)
        {
            try
            {
                var existingRobot = await _robotService.GetRobotByID(id);
                if (existingRobot != null)
                {
                    var result = await _robotService.RemoveRobot(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Robot thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Robot không tìm thấy hoặc xóa không thành công."
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
