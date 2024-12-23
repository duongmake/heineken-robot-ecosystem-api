using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class GiftRepository : IGiftRepository
    {
        private readonly IGiftDAO _giftDao;
        public GiftRepository()
        {
            _giftDao = new GiftDAO();
        }

        public async Task CreateGift(Gift gift)
        {
            try
            {
                await _giftDao.Add(gift);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Gift> GetAllGift()
        {
            try
            {
                var gifts = _giftDao.GetAll();
                if (gifts != null)
                {
                    return gifts;
                }
                throw new Exception("Gift not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Gift> GetGiftByID(Guid id)
        {
            try
            {
                return _giftDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveGift(Guid id)
        {
            try
            {
                return await _giftDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateGift(GiftUpdateDTO gift, Guid id)
        {
            try
            {
                var existGift = await _giftDao.GetByID(id);
                if (existGift != null)
                {
                    if (!string.IsNullOrEmpty(gift.GiftName))
                    {
                        existGift.GiftName = gift.GiftName;
                    }
                    if (!string.IsNullOrEmpty(gift.Description))
                    {
                        existGift.Description = gift.Description;
                    }
                    if (gift.TotalCount.HasValue)
                    {
                        existGift.TotalCount = gift.TotalCount.Value;
                    }
                    if (gift.RedeemedCount.HasValue)
                    {
                        existGift.RedeemedCount = gift.RedeemedCount.Value;
                    }
                    if (gift.ExpiredCount.HasValue)
                    {
                        existGift.ExpiredCount = gift.ExpiredCount.Value;
                    }

                    await _giftDao.Update(existGift);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
