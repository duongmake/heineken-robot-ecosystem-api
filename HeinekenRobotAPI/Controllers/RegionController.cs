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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;
        public RegionController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            try
            {
                var regions = await _regionService.GetAllRegion().ToListAsync();

                if (regions == null || !regions.Any())
                {
                    return NotFound(new
                    {
                        message = "Region not found."
                    });
                }

                var response = _mapper.Map<List<RegionVM>>(regions);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionByID(Guid id)
        {
            var region = await _regionService.GetRegionByID(id);

            if (region != null)
            {
                var responese = _mapper.Map<RegionVM>(region);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Region không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] RegionCreateDTO region)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newRegion = new RegionCreateDTO
                {
                    RegionId = Guid.NewGuid(),
                    RegionName = region.RegionName,
                    Province = region.Province
                };
                var _region = _mapper.Map<Region>(newRegion);

                await _regionService.CreateRegion(_region);
                return Ok(new
                {
                    message = "Tạo Region thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion([FromForm] RegionUpdateDTO region, Guid id)
        {
            try
            {
                var existingRegion = _regionService.GetRegionByID(id);
                if (existingRegion != null)
                {
                    await _regionService.UpdateRegion(region, id);

                    return Ok(new
                    {
                        message = "Cập nhật Region thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Region không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRegion(Guid id)
        {
            try
            {
                var existingRegion = await _regionService.GetRegionByID(id);
                if (existingRegion != null)
                {
                    var result = await _regionService.RemoveRegion(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Region thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Region không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Region không tồn tại."
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
