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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var locations = await _locationService.GetAllLocation().ToListAsync();

                if (locations == null || !locations.Any())
                {
                    return NotFound(new
                    {
                        message = "Location not found."
                    });
                }

                var response = _mapper.Map<List<LocationVM>>(locations);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationByID(Guid id)
        {
            var location = await _locationService.GetLocationByID(id);

            if (location != null)
            {
                var responese = _mapper.Map<LocationVM>(location);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Location không tồn tại."
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] LocationCreateDTO location)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newLocation = new LocationCreateDTO
                {
                    LocationId = Guid.NewGuid(),
                    LocationName = location.LocationName,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    RegionId = location.RegionId
                };
                var _location = _mapper.Map<Location>(newLocation);

                await _locationService.CreateLocation(_location);
                return Ok(new
                {
                    message = "Tạo Location thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation([FromForm] LocationUpdateDTO location, Guid id)
        {
            try
            {
                var existingLocation = _locationService.GetLocationByID(id);
                if (existingLocation != null)
                {
                    await _locationService.UpdateLocation(location, id);

                    return Ok(new
                    {
                        message = "Cập nhật Location thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Location không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(Guid id)
        {
            try
            {
                var existingLocation = await _locationService.GetLocationByID(id);
                if (existingLocation != null)
                {
                    var result = await _locationService.RemoveLocation(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Location thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Location không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Location không tồn tại."
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
