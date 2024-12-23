using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _giftRepo;
        public GiftService(IGiftRepository giftRepo)
        {
            _giftRepo = giftRepo;
        }

        public Task CreateGift(Gift gift) => _giftRepo.CreateGift(gift);

        public IQueryable<Gift> GetAllGift() => _giftRepo.GetAllGift();

        public Task<Gift> GetGiftByID(Guid id) => _giftRepo.GetGiftByID(id);

        public Task<bool> RemoveGift(Guid id) => _giftRepo.RemoveGift(id);

        public Task UpdateGift(GiftUpdateDTO gift, Guid id) => _giftRepo.UpdateGift(gift, id);

    }
}
