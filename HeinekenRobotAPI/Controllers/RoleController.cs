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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var roles = await _roleService.GetAllRole().ToListAsync();

                if (roles == null || !roles.Any())
                {
                    return NotFound(new
                    {
                        message = "Role not found."
                    });
                }

                var response = _mapper.Map<List<RoleVM>>(roles);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByID(Guid id)
        {
            var role = await _roleService.GetRoleByID(id);

            if (role != null)
            {
                var responese = _mapper.Map<RoleVM>(role);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Role không tồn tại."
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDTO role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newRole = new RoleCreateDTO
                {
                    RoleID = Guid.NewGuid(),
                    RoleName = role.RoleName
                };
                var _role = _mapper.Map<Role>(newRole);

                await _roleService.CreateRole(_role);
                return Ok(new
                {
                    message = "Tạo Role thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromForm] RoleUpdateDTO Role, Guid id)
        {
            try
            {
                var existingRole = _roleService.GetRoleByID(id);
                if (existingRole != null)
                {
                    await _roleService.UpdateRole(Role, id);

                    return Ok(new
                    {
                        message = "Cập nhật Role thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Role không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRole(Guid id)
        {
            try
            {
                var existingRole = await _roleService.GetRoleByID(id);
                if (existingRole != null)
                {
                    var result = await _roleService.RemoveRole(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Role thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Role không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Role không tồn tại."
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
