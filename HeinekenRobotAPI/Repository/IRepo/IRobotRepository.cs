using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRobotRepository
    {
        IQueryable<Robot> GetAllRobot();
        Task<Robot> GetRobotByID(Guid id);
        Task CreateRobot(Robot robot);
        Task<Robot> UpdateRobot(Robot robot, Guid id);
    }
}
