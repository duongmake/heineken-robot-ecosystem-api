using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
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

        public Task<bool> RemoveRobot(Guid id) => _robotRepo.RemoveRobot(id);

        public Task UpdateRobot(RobotUpdateDTO robot, Guid id) => _robotRepo.UpdateRobot(robot, id);
    }
}
