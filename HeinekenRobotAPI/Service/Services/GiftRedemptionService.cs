using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class GiftRedemptionService : IGiftRedemptionService
    {
        private readonly IGiftRedemptionRepository _redemRepo;
        public GiftRedemptionService(IGiftRedemptionRepository redemRepo)
        {
            _redemRepo = redemRepo;
        }

        public Task CreateGiftRedemption(GiftRedemption redemption) => _redemRepo.CreateGiftRedemption(redemption);

        public IQueryable<GiftRedemption> GetAllGiftRedemption() => _redemRepo.GetAllGiftRedemption();

        public Task<GiftRedemption> GetGiftRedemptionByID(Guid id) => _redemRepo.GetGiftRedemptionByID(id);

        public Task<bool> RemoveGiftRedemption(Guid id) => _redemRepo.RemoveGiftRedemption(id);

        public Task UpdateGiftRedemption(GiftRedemptionUpdateDTO redemption, Guid id) => _redemRepo.UpdateGiftRedemption(redemption, id);

    }
}
