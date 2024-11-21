using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRobotRepository
    {
        IQueryable<Robot> GetAllRobot();
        Task<Robot> GetRobotByID(Guid id);
        Task CreateRobot(Robot robot);
        Task UpdateRobot(RobotUpdateDTO robot, Guid id);
        Task<bool> RemoveRobot(Guid id);
    }
}
