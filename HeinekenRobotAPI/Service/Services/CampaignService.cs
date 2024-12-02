using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepo;
        public CampaignService(ICampaignRepository campaignRepo)
        {
            _campaignRepo = campaignRepo;
        }

        public Task CreateCampaign(Campaign campain) => _campaignRepo.CreateCampaign(campain);

        public IQueryable<Campaign> GetAllCampaign() => _campaignRepo.GetAllCampaign();

        public Task<Campaign> GetCampaignByID(Guid id) => _campaignRepo.GetCampaignByID(id);

        public Task<bool> RemoveCampaign(Guid id) => _campaignRepo.RemoveCampaign(id);

        public Task UpdateCampaign(CampaignUpdateDTO campain, Guid id) => _campaignRepo.UpdateCampaign(campain, id);

    }
}
