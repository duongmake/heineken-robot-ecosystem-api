using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using static Humanizer.In;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RobotRepository : IRobotRepository
    {
        private readonly IRobotDAO _robotDao;
        public RobotRepository()
        {
            _robotDao = new RobotDAO();
        }

        public IQueryable<Robot> GetAllRobot()
        {
            try
            {
                var robots = _robotDao.GetAll().Include(s => s.RobotType)
                                                      .Include(s => s.Location);
                if (robots != null)
                {
                    return robots;
                }
                throw new Exception("Robot not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Robot> GetRobotByID(Guid id)
        {
            try
            {
                return _robotDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task CreateRobot(Robot robot)
        {
            try
            {
                await _robotDao.Add(robot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRobot(RobotUpdateDTO robot, Guid id)
        {
            try
            {
                var existRobot = await _robotDao.GetByID(id);
                if (existRobot != null)
                {
                    if (!string.IsNullOrEmpty(robot.RobotName))
                    {
                        existRobot.RobotName = robot.RobotName;
                    }
                    if (!string.IsNullOrEmpty(robot.Status))
                    {
                        existRobot.Status = robot.Status;
                    }
                    if (robot.BatteryLevel.HasValue)
                    {
                        existRobot.BatteryLevel = robot.BatteryLevel.Value;
                    }
                    if (robot.LastAccessTime.HasValue)
                    {
                        existRobot.LastAccessTime = robot.LastAccessTime.Value;
                    }
                    if (robot.RobotTypeId.HasValue)
                    {
                        existRobot.RobotTypeId = robot.RobotTypeId.Value;
                    }
                    if (robot.LocationId.HasValue)
                    {
                        existRobot.LocationId = robot.LocationId.Value;
                    }

                    await _robotDao.Update(existRobot);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveRobot(Guid id)
        {
            try
            {
                return await _robotDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
