using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class GiftRedemptionRepository : IGiftRedemptionRepository
    {
        private readonly IGiftRedemptionDAO _redemDao;
        public GiftRedemptionRepository()
        {
            _redemDao = new GiftRedemptionDAO();
        }

        public async Task CreateGiftRedemption(GiftRedemption redemption)
        {
            try
            {
                await _redemDao.Add(redemption);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<GiftRedemption> GetAllGiftRedemption()
        {
            try
            {
                var gifts = _redemDao.GetAll().Include(s => s.Campaign)
                                              .Include(s => s.Gift)
                                              .Include(s => s.User)
                                              .Include(s => s.RecycleMachine);
                if (gifts != null)
                {
                    return gifts;
                }
                throw new Exception("GiftRedemption not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<GiftRedemption> GetGiftRedemptionByID(Guid id)
        {
            try
            {
                return _redemDao.GetByIDInclude(id, s => s.Campaign);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveGiftRedemption(Guid id)
        {
            try
            {
                return await _redemDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateGiftRedemption(GiftRedemptionUpdateDTO redemption, Guid id)
        {
            try
            {
                var existRedemption = await _redemDao.GetByID(id);
                if (existRedemption != null)
                {
                    if (!string.IsNullOrEmpty(redemption.QrCode))
                    {
                        existRedemption.QrCode = redemption.QrCode;
                    }
                    if (!string.IsNullOrEmpty(redemption.Status))
                    {
                        existRedemption.Status = redemption.Status;
                    }
                    if (redemption.RedemptionDate.HasValue)
                    {
                        existRedemption.RedemptionDate = redemption.RedemptionDate.Value;
                    }
                    if (redemption.RedeemedAt.HasValue)
                    {
                        existRedemption.RedeemedAt = redemption.RedeemedAt.Value;
                    }
                    if (redemption.CampaignId.HasValue)
                    {
                        existRedemption.CampaignId = redemption.CampaignId.Value;
                    }
                    if (redemption.GiftId.HasValue)
                    {
                        existRedemption.GiftId = redemption.GiftId.Value;
                    }
                    if (redemption.UserId.HasValue)
                    {
                        existRedemption.UserId = redemption.UserId.Value;
                    }
                    if (redemption.RecycleMachineId.HasValue)
                    {
                        existRedemption.RecycleMachineId = redemption.RecycleMachineId.Value;
                    }

                    await _redemDao.Update(existRedemption);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
