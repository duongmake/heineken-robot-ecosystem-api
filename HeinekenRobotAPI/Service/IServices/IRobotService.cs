using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IRobotService
    {
        IQueryable<Robot> GetAllRobot();
        Task<Robot> GetRobotByID(Guid id);
        Task CreateRobot(Robot robot);
        Task<Robot> UpdateRobot(Robot robot, Guid id);
    }
}
