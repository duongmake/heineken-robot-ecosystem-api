using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IGiftRedemptionService
    {
        IQueryable<GiftRedemption> GetAllGiftRedemption();
        Task<GiftRedemption> GetGiftRedemptionByID(Guid id);
        Task CreateGiftRedemption(GiftRedemption redemption);
        Task UpdateGiftRedemption(GiftRedemptionUpdateDTO redemption, Guid id);
        Task<bool> RemoveGiftRedemption(Guid id);
    }
}
