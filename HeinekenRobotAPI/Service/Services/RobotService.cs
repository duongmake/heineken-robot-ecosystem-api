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

        public Task CreateRobot(Robot robot) => _robotRepo.CreateRobot(robot);

        public IQueryable<Robot> GetAllRobot() => _robotRepo.GetAllRobot();

        public Task<Robot> GetRobotByID(Guid id) => _robotRepo.GetRobotByID(id);

        public Task<Robot> UpdateRobot(Robot robot, Guid id) => _robotRepo.UpdateRobot(robot, id);
    }
}
