using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRobotTypeRepository
    {
        IQueryable<RobotType> GetAllRobotType();
        Task<RobotType> GetRobotTypeByID(Guid id);
        Task CreateRobotType(RobotType type);
        Task UpdateRobotType(RobotTypeUpdateDTO type, Guid id);
        Task<bool> RemoveRobotType(Guid id);
    }
}
