using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IGiftService
    {
        IQueryable<Gift> GetAllGift();
        Task<Gift> GetGiftByID(Guid id);
        Task CreateGift(Gift gift);
        Task UpdateGift(GiftUpdateDTO gift, Guid id);
        Task<bool> RemoveGift(Guid id);
    }
}
