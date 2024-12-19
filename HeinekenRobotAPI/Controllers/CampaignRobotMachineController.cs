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
    public class CampaignRobotMachineController : ControllerBase
    {
        private readonly ICampaignRobotMachineService _machineService;
        private readonly IMapper _mapper;
        public CampaignRobotMachineController(ICampaignRobotMachineService machineService, IMapper mapper)
        {
            _machineService = machineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCampaignRobotMachine()
        {
            try
            {
                var machines = await _machineService.GetAllCampaignRobotMachine().ToListAsync();

                if (machines == null || !machines.Any())
                {
                    return NotFound(new
                    {
                        message = "CampaignRobotMachine not found."
                    });
                }

                var response = _mapper.Map<List<CampaignRobotMachineVM>>(machines);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignRobotMachineByID(Guid id)
        {
            var machine = await _machineService.GetCampaignRobotMachineByID(id);

            if (machine != null)
            {
                var responese = _mapper.Map<CampaignRobotMachineVM>(machine);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "CampaignRobotMachine không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaignRobotMachine([FromBody] CampaignRobotMachineCreateDTO machine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newMachine = new CampaignRobotMachineCreateDTO
                {
                    CampaignRobotMachineId = Guid.NewGuid(),
                    CampaignId = machine.CampaignId,
                    RobotId = machine.RobotId,
                    RecycleMachineId = machine.RecycleMachineId,
                    LocationId = machine.LocationId,
                    AssignedDate = machine.AssignedDate,
                    Status = machine.Status
                };
                var _machine = _mapper.Map<CampaignRobotMachine>(newMachine);

                await _machineService.CreateCampaignRobotMachine(_machine);
                return Ok(new
                {
                    message = "Tạo CampaignRobotMachine thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCampaignRobotMachine([FromForm] CampaignRobotMachineUpdateDTO machine, Guid id)
        {
            try
            {
                var existingMachine = _machineService.GetCampaignRobotMachineByID(id);
                if (existingMachine != null)
                {
                    await _machineService.UpdateCampaignRobotMachine(machine, id);

                    return Ok(new
                    {
                        message = "Cập nhật CampaignRobotMachine thành công."
                    });

                }

                return NotFound(new
                {
                    message = "CampaignRobotMachine không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCampaignRobotMachine(Guid id)
        {
            try
            {
                var existingMachine = await _machineService.GetCampaignRobotMachineByID(id);
                if (existingMachine != null)
                {
                    var result = await _machineService.RemoveCampaignRobotMachine(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa CampaignRobotMachine thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "CampaignRobotMachine không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "CampaignRobotMachine không tồn tại."
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
