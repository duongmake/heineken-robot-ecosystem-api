using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRobotRepository
    {
        IQueryable<Robot> GetAllRobot();
    }
}
