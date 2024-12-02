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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _userService.GetAllUser().ToListAsync();

                if (users == null || !users.Any())
                {
                    return NotFound(new
                    {
                        message = "Người dùng not found."
                    });
                }

                var response = _mapper.Map<List<UserVM>>(users);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(Guid id)
        {
            var user = await _userService.GetUserByID(id);

            if (user != null)
            {
                var responese = _mapper.Map<UserVM>(user);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Người dùng không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateRobot([FromBody] UserCreateDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newUser = new UserCreateDTO
                {
                    UserId = Guid.NewGuid(),
                    UserName = user.UserName,
                    Password = user.Password,
                    FullName = user.FullName,
                    Email = user.Email,
                    RoleID = user.RoleID
                };
                var _user = _mapper.Map<User>(newUser);

                await _userService.CreateUser(_user);
                return Ok(new
                {
                    message = "Tạo người dùng thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] UserUpdateDTO user, Guid id)
        {
            try
            {
                var existingUser = _userService.GetUserByID(id);
                if (existingUser != null)
                {
                    await _userService.UpdateUser(user, id);

                    return Ok(new
                    {
                        message = "Cập nhật người dùng thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Người dùng không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            try
            {
                var existingUser = await _userService.GetUserByID(id);
                if (existingUser != null)
                {
                    var result = await _userService.RemoveUser(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa người dùng thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Người dùng không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Người dùng không tồn tại."
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
