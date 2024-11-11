using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepo;
        public RobotService(IRobotRepository robotRepo)
        {
            _robotRepo = robotRepo;
        }

        public IQueryable<Robot> GetAllRobot() => _robotRepo.GetAllRobot();
    }
}
