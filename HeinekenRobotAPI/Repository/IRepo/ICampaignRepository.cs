using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface ICampaignRepository
    {
        IQueryable<Campaign> GetAllCampaign();
        Task<Campaign> GetCampaignByID(Guid id);
        Task CreateCampaign(Campaign campain);
        Task UpdateCampaign(CampaignUpdateDTO campain, Guid id);
        Task<bool> RemoveCampaign(Guid id);
    }
}
