using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IGiftRepository
    {
        IQueryable<Gift> GetAllGift();
        Task<Gift> GetGiftByID(Guid id);
        Task CreateGift(Gift gift);
        Task UpdateGift(GiftUpdateDTO gift, Guid id);
        Task<bool> RemoveGift(Guid id);
    }
}
