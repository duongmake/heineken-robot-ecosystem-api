using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepo;
        public RegionService(IRegionRepository regionRepo)
        {
            _regionRepo = regionRepo;
        }

        public Task CreateRegion(Region region) => _regionRepo.CreateRegion(region);

        public IQueryable<Region> GetAllRegion() => _regionRepo.GetAllRegion();

        public Task<Region> GetRegionByID(Guid id) => _regionRepo.GetRegionByID(id);

        public Task<bool> RemoveRegion(Guid id) => _regionRepo.RemoveRegion(id);

        public Task UpdateRegion(RegionUpdateDTO region, Guid id) => _regionRepo.UpdateRegion(region, id);

    }
}
