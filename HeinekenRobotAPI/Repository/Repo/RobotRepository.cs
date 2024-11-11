using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

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

    }
}
