using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface ICampaignRobotMachineDAO : IBaseDAO<CampaignRobotMachine, Guid> { }
    public class CampaignRobotMachineDAO : BaseDAO<CampaignRobotMachine, Guid>, ICampaignRobotMachineDAO
    {
    }
}
