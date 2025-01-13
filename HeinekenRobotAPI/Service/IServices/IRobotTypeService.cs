using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Service.IServices
{
    public interface IRobotTypeService
    {
        IQueryable<RobotType> GetAllRobotType();
        Task<RobotType> GetRobotTypeByID(Guid id);
        Task CreateRobotType(RobotType type);
        Task UpdateRobotType(RobotTypeUpdateDTO type, Guid id);
        Task<bool> RemoveRobotType(Guid id);
    }
}
