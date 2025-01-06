using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IRegionDAO _regionDao;
        public RegionRepository()
        {
            _regionDao = new RegionDAO();
        }

        public async Task CreateRegion(Region region)
        {
            try
            {
                await _regionDao.Add(region);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Region> GetAllRegion()
        {
            try
            {
                var regions = _regionDao.GetAll();
                if (regions != null)
                {
                    return regions;
                }
                throw new Exception("Region not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Region> GetRegionByID(Guid id)
        {
            try
            {
                return _regionDao.GetByID(id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveRegion(Guid id)
        {
            try
            {
                return await _regionDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRegion(RegionUpdateDTO region, Guid id)
        {
            try
            {
                var existRegion = await _regionDao.GetByID(id);
                if (existRegion != null)
                {
                    if (!string.IsNullOrEmpty(region.RegionName))
                    {
                        existRegion.RegionName = region.RegionName;
                    }
                    if (!string.IsNullOrEmpty(region.Province))
                    {
                        existRegion.Province = region.Province;
                    }

                    await _regionDao.Update(existRegion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
