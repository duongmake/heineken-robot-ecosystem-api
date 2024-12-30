using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepo;
        public LocationService(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public Task CreateLocation(Location location) => _locationRepo.CreateLocation(location);

        public IQueryable<Location> GetAllLocation() => _locationRepo.GetAllLocation();

        public Task<Location> GetLocationByID(Guid id) => _locationRepo.GetLocationByID(id);

        public Task<bool> RemoveLocation(Guid id) => _locationRepo.RemoveLocation(id);

        public Task UpdateLocation(LocationUpdateDTO location, Guid id) => _locationRepo.UpdateLocation(location, id);

    }
}
