using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface IRecycleMachineRepository
    {
        IQueryable<RecycleMachine> GetAllRecycleMachine();
        Task<RecycleMachine> GetRecycleMachineByID(Guid id);
        Task CreateRecycleMachine(RecycleMachine machine);
        Task UpdateRecycleMachine(RecycleMachineUpdateDTO machine, Guid id);
        Task<bool> RemoveRecycleMachine(Guid id);
    }
}
