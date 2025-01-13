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
    public class RobotTypeController : ControllerBase
    {
        private readonly IRobotTypeService _typeService;
        private readonly IMapper _mapper;
        public RobotTypeController(IRobotTypeService typeService, IMapper mapper)
        {
            _typeService = typeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRobotType()
        {
            try
            {
                var types = await _typeService.GetAllRobotType().ToListAsync();

                if (types == null || !types.Any())
                {
                    return NotFound(new
                    {
                        message = "RobotType not found."
                    });
                }

                var response = _mapper.Map<List<RobotTypeVM>>(types);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotTypeByID(Guid id)
        {
            var type = await _typeService.GetRobotTypeByID(id);

            if (type != null)
            {
                var responese = _mapper.Map<RobotTypeVM>(type);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "RobotType không tồn tại."
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRobotType([FromBody] RobotTypeCreateDTO type)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newType = new RobotTypeCreateDTO
                {
                    RobotTypeId = Guid.NewGuid(),
                    RobotTypeName = type.RobotTypeName
                };
                var _type = _mapper.Map<RobotType>(newType);

                await _typeService.CreateRobotType(_type);
                return Ok(new
                {
                    message = "Tạo RobotType thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRobotType([FromForm] RobotTypeUpdateDTO type, Guid id)
        {
            try
            {
                var existingType = _typeService.GetRobotTypeByID(id);
                if (existingType != null)
                {
                    await _typeService.UpdateRobotType(type, id);

                    return Ok(new
                    {
                        message = "Cập nhật RobotType thành công."
                    });

                }

                return NotFound(new
                {
                    message = "RobotType không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRobotType(Guid id)
        {
            try
            {
                var existingType = await _typeService.GetRobotTypeByID(id);
                if (existingType != null)
                {
                    var result = await _typeService.RemoveRobotType(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa RobotType thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "RobotType không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "RobotType không tồn tại."
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
