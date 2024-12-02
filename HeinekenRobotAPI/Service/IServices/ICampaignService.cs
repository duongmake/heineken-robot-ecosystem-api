using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface ICampaignService
    {
        IQueryable<Campaign> GetAllCampaign();
        Task<Campaign> GetCampaignByID(Guid id);
        Task CreateCampaign(Campaign campain);
        Task UpdateCampaign(CampaignUpdateDTO campain, Guid id);
        Task<bool> RemoveCampaign(Guid id);
    }
}
