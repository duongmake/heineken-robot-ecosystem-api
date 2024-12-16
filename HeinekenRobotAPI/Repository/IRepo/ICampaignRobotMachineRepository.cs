using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface ICampaignRobotMachineRepository
    {
        IQueryable<CampaignRobotMachine> GetAllCampaignRobotMachine();
        Task<CampaignRobotMachine> GetCampaignRobotMachineByID(Guid id);
        Task CreateCampaignRobotMachine(CampaignRobotMachine machine);
        Task UpdateCampaignRobotMachine(CampaignRobotMachineUpdateDTO machine, Guid id);
        Task<bool> RemoveCampaignRobotMachine(Guid id);
    }
}
