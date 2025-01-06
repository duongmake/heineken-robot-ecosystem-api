using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRegionRepository
    {
        IQueryable<Region> GetAllRegion();
        Task<Region> GetRegionByID(Guid id);
        Task CreateRegion(Region region);
        Task UpdateRegion(RegionUpdateDTO region, Guid id);
        Task<bool> RemoveRegion(Guid id);
    }
}
