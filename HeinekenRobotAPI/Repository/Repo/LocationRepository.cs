using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILocationDAO _locationDao;
        public LocationRepository()
        {
            _locationDao = new LocationDAO();
        }

        public async Task CreateLocation(Location location)
        {
            try
            {
                await _locationDao.Add(location);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<Location> GetAllLocation()
        {
            try
            {
                var locations = _locationDao.GetAll().Include(s => s.Region);
                if (locations != null)
                {
                    return locations;
                }
                throw new Exception("Location not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Location> GetLocationByID(Guid id)
        {
            try
            {
                return _locationDao.GetByIDInclude(id, s => s.Region);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveLocation(Guid id)
        {
            try
            {
                return await _locationDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateLocation(LocationUpdateDTO location, Guid id)
        {
            try
            {
                var existLocaiton = await _locationDao.GetByID(id);
                if (existLocaiton != null)
                {
                    if (!string.IsNullOrEmpty(location.LocationName))
                    {
                        existLocaiton.LocationName = location.LocationName;
                    }
                    if (location.Latitude.HasValue)
                    {
                        existLocaiton.Latitude = location.Latitude.Value;
                    }
                    if (location.Longitude.HasValue)
                    {
                        existLocaiton.Longitude = location.Longitude.Value;
                    }
                    if (location.RegionId.HasValue)
                    {
                        existLocaiton.RegionId = location.RegionId.Value;
                    }

                    await _locationDao.Update(existLocaiton);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
