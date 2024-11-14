using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;
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
                var robot = _robotDao.GetByID(id);
                if (robot != null)
                {
                    return robot;

                }
                throw new Exception($"robot have {id} is not found.");
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

        public async Task<Robot> UpdateRobot(Robot robot, Guid id)
        {
            try
            {
                var existRobot = await _robotDao.GetByID(id);
                if (existRobot != null)
                {
                    existRobot.RobotName = robot.RobotName;
                    existRobot.Status = robot.Status;
                    existRobot.BatteryLevel = robot.BatteryLevel;
                    existRobot.LastAccessTime = robot.LastAccessTime;
                    existRobot.RobotTypeId = robot.RobotTypeId;
                    existRobot.LocationId = robot.LocationId;

                    await _robotDao.Update(existRobot);
                }

                return existRobot;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
