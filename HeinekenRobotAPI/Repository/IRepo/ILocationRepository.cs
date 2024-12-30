using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface ILocationRepository
    {
        IQueryable<Location> GetAllLocation();
        Task<Location> GetLocationByID(Guid id);
        Task CreateLocation(Location location);
        Task UpdateLocation(LocationUpdateDTO location, Guid id);
        Task<bool> RemoveLocation(Guid id);
    }
}
