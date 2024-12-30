using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface ILocationService
    {
        IQueryable<Location> GetAllLocation();
        Task<Location> GetLocationByID(Guid id);
        Task CreateLocation(Location location);
        Task UpdateLocation(LocationUpdateDTO location, Guid id);
        Task<bool> RemoveLocation(Guid id);
    }
}
