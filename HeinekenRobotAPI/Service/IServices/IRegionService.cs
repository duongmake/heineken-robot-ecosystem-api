using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IRegionService
    {
        IQueryable<Region> GetAllRegion();
        Task<Region> GetRegionByID(Guid id);
        Task CreateRegion(Region region);
        Task UpdateRegion(RegionUpdateDTO region, Guid id);
        Task<bool> RemoveRegion(Guid id);
    }
}
