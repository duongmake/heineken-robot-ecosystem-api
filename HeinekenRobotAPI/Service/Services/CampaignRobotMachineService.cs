using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class CampaignRobotMachineService : ICampaignRobotMachineService
    {
        private readonly ICampaignRobotMachineRepository _machineRepo;
        public CampaignRobotMachineService(ICampaignRobotMachineRepository machineRepo)
        {
            _machineRepo = machineRepo;
        }

        public Task CreateCampaignRobotMachine(CampaignRobotMachine machine) => _machineRepo.CreateCampaignRobotMachine(machine);

        public IQueryable<CampaignRobotMachine> GetAllCampaignRobotMachine() => _machineRepo.GetAllCampaignRobotMachine();

        public Task<CampaignRobotMachine> GetCampaignRobotMachineByID(Guid id) => _machineRepo.GetCampaignRobotMachineByID(id);

        public Task<bool> RemoveCampaignRobotMachine(Guid id) => _machineRepo.RemoveCampaignRobotMachine(id);

        public Task UpdateCampaignRobotMachine(CampaignRobotMachineUpdateDTO machine, Guid id) => _machineRepo.UpdateCampaignRobotMachine(machine, id);

    }
}
