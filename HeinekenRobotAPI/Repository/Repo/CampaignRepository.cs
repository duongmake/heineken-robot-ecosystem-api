using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ICampaignDAO _campaignDao;
        public CampaignRepository()
        {
            _campaignDao = new CampaignDAO();
        }

        public async Task CreateCampaign(Campaign campain)
        {
            try
            {
                await _campaignDao.Add(campain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Campaign> GetAllCampaign()
        {
            try
            {
                var campains = _campaignDao.GetAll().Include(s => s.Region);
                if (campains != null)
                {
                    return campains;
                }
                throw new Exception("Campaign not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Campaign> GetCampaignByID(Guid id)
        {
            try
            {
                return _campaignDao.GetByIDInclude(id, s => s.Region);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveCampaign(Guid id)
        {
            try
            {
                return await _campaignDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCampaign(CampaignUpdateDTO campain, Guid id)
        {
            try
            {
                var existCampaign = await _campaignDao.GetByID(id);
                if (existCampaign != null)
                {
                    if (!string.IsNullOrEmpty(campain.CampaignName))
                    {
                        existCampaign.CampaignName = campain.CampaignName;
                    }
                    if (!string.IsNullOrEmpty(campain.Description))
                    {
                        existCampaign.Description = campain.Description;
                    }
                    if (campain.StartDate.HasValue)
                    {
                        existCampaign.StartDate = campain.StartDate.Value;
                    }
                    if (campain.EndDate.HasValue)
                    {
                        existCampaign.EndDate = campain.EndDate.Value;
                    }
                    if (!string.IsNullOrEmpty(campain.Status))
                    {
                        existCampaign.Status = campain.Status;
                    }
                    if (campain.RegionId.HasValue)
                    {
                        existCampaign.RegionId = campain.RegionId.Value;
                    }

                    await _campaignDao.Update(existCampaign);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
