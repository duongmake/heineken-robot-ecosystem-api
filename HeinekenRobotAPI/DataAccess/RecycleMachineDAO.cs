using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IRecycleMachineDAO : IBaseDAO<RecycleMachine, Guid> { }
    public class RecycleMachineDAO : BaseDAO<RecycleMachine, Guid>, IRecycleMachineDAO
    {
    }
}
