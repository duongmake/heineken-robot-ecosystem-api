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
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        private readonly IMapper _mapper;
        public GiftController(IGiftService giftService, IMapper mapper)
        {
            _giftService = giftService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGift()
        {
            try
            {
                var gifts = await _giftService.GetAllGift().ToListAsync();

                if (gifts == null || !gifts.Any())
                {
                    return NotFound(new
                    {
                        message = "Gift not found."
                    });
                }

                var response = _mapper.Map<List<GiftVM>>(gifts);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftByID(Guid id)
        {
            var gift = await _giftService.GetGiftByID(id);

            if (gift != null)
            {
                var responese = _mapper.Map<GiftVM>(gift);

                return Ok(responese);
            }

            return NotFound(new
            {
                message = "Gift không tồn tại."
            });

        }

        [HttpPost]
        public async Task<IActionResult> CreateGift([FromBody] GiftCreateDTO gift)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newGift = new GiftCreateDTO
                {
                    GiftId = Guid.NewGuid(),
                    GiftName = gift.GiftName,
                    Description = gift.Description,
                    TotalCount = gift.TotalCount,
                    RedeemedCount = gift.RedeemedCount,
                    ExpiredCount = gift.ExpiredCount
                };
                var _gift = _mapper.Map<Gift>(newGift);

                await _giftService.CreateGift(_gift);
                return Ok(new
                {
                    message = "Tạo Gift thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGift([FromForm] GiftUpdateDTO gift, Guid id)
        {
            try
            {
                var existingGift = _giftService.GetGiftByID(id);
                if (existingGift != null)
                {
                    await _giftService.UpdateGift(gift, id);

                    return Ok(new
                    {
                        message = "Cập nhật Gift thành công."
                    });

                }

                return NotFound(new
                {
                    message = "Gift không tồn tại."
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGift(Guid id)
        {
            try
            {
                var existingGift = await _giftService.GetGiftByID(id);
                if (existingGift != null)
                {
                    var result = await _giftService.RemoveGift(id);
                    if (result)
                    {
                        return Ok(new
                        {
                            message = "Xóa Gift thành công."
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            message = "Gift không tìm thấy hoặc xóa không thành công."
                        });
                    }
                }

                return NotFound(new
                {
                    message = "Gift không tồn tại."
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
