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
    public class GiftRedemptionController : ControllerBase
    {
        private readonly IGiftRedemptionService _redemService;
        private readonly IMapper _mapper;
        public GiftRedemptionController(IGiftRedemptionService redemService, IMapper mapper)
        {
            _redemService = redemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiftRedemption()
        {
            try
            {
                var redems = await _redemService.GetAllGiftRedemption().ToListAsync();

                if (redems == null || !redems.Any())
                {
                    return NotFound(new
                    {
                        message = "GiftRedemption not found."
                    });
                }

                var response = _mapper.Map<List<GiftRedemptionVM>>(redems);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftRedemptionByID(Guid id)
        {
            var redem = await _redemService.GetGiftRedemptionByID(id);

            if (redem != null)
            {
                var responese = _mapper.Map<GiftRedemptionVM>(redem);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "GiftRedemption không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateGiftRedemption([FromBody] GiftRedemptionCreateDTO redem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newRedem = new GiftRedemptionCreateDTO
                {
                    GiftRedemptionId = Guid.NewGuid(),
                    CampaignId = redem.CampaignId,
                    GiftId = redem.GiftId,
                    UserId = redem.UserId,
                    RecycleMachineId = redem.RecycleMachineId,
                    RedemptionDate = redem.RedemptionDate,
                    QrCode = redem.QrCode,
                    Status = redem.Status,
                    RedeemedAt = redem.RedeemedAt
                };
                var _redem = _mapper.Map<GiftRedemption>(newRedem);

                await _redemService.CreateGiftRedemption(_redem);
                return Ok(new
                {
                    message = "Tạo GiftRedemption thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGiftRedemption([FromForm] GiftRedemptionUpdateDTO redemption, Guid id)
        {
            try
            {
                var existingRedem = _redemService.GetGiftRedemptionByID(id);
                if (existingRedem != null)
                {
                    await _redemService.UpdateGiftRedemption(redemption, id);

                    return Ok(new
                    {
                        message = "Cập nhật GiftRedemption thành công."
                    });

                }

                return NotFound(new
                {
                    message = "GiftRedemption không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGiftRedemption(Guid id)
        {
            try
            {
                var existingRedem = await _redemService.GetGiftRedemptionByID(id);
                if (existingRedem != null)
                {
                    var result = await _redemService.RemoveGiftRedemption(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa GiftRedemption thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "GiftRedemption không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "GiftRedemption không tồn tại."
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
