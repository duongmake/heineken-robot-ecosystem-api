using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IRobotService
    {
        IQueryable<Robot> GetAllRobot();
    }
}
