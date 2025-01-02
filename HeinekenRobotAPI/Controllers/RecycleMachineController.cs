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
    public class RecycleMachineController : ControllerBase
    {
        private readonly IRecycleMachineService _machineService;
        private readonly IMapper _mapper;
        public RecycleMachineController(IRecycleMachineService machineService, IMapper mapper)
        {
            _machineService = machineService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecycleMachine()
        {
            try
            {
                var machines = await _machineService.GetAllRecycleMachine().ToListAsync();

                if (machines == null || !machines.Any())
                {
                    return NotFound(new
                    {
                        message = "RecycleMachine not found."
                    });
                }

                var response = _mapper.Map<List<RecycleMachineVM>>(machines);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecycleMachineByID(Guid id)
        {
            var machine = await _machineService.GetRecycleMachineByID(id);

            if (machine != null)
            {
                var responese = _mapper.Map<RecycleMachineVM>(machine);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "RecycleMachine không tồn tại."
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecycleMachine([FromBody] RecycleMachineCreateDTO machine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newMachine = new RecycleMachineCreateDTO
                {
                    RecycleMachineId = Guid.NewGuid(),
                    MachineCode = machine.MachineCode,
                    Status = machine.Status,
                    ContainerStatus = machine.ContainerStatus,
                    LastServiceDate = machine.LastServiceDate,
                    CreateTime = machine.CreateTime,
                    Interaction = machine.Interaction,
                    LocationId = machine.LocationId
                };
                var _machine = _mapper.Map<RecycleMachine>(newMachine);

                await _machineService.CreateRecycleMachine(_machine);
                return Ok(new
                {
                    message = "Tạo RecycleMachine thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecycleMachine([FromForm] RecycleMachineUpdateDTO machine, Guid id)
        {
            try
            {
                var existingMachine = _machineService.GetRecycleMachineByID(id);
                if (existingMachine != null)
                {
                    await _machineService.UpdateRecycleMachine(machine, id);

                    return Ok(new
                    {
                        message = "Cập nhật RecycleMachine thành công."
                    });

                }

                return NotFound(new
                {
                    message = "RecycleMachine không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRecycleMachine(Guid id)
        {
            try
            {
                var existingMachine = await _machineService.GetRecycleMachineByID(id);
                if (existingMachine != null)
                {
                    var result = await _machineService.RemoveRecycleMachine(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa RecycleMachine thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "RecycleMachine không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "RecycleMachine không tồn tại."
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
