using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RecycleMachineService : IRecycleMachineService
    {
        private readonly IRecycleMachineRepository _machineRepo;
        public RecycleMachineService(IRecycleMachineRepository machineRepo)
        {
            _machineRepo = machineRepo;
        }

        public Task CreateRecycleMachine(RecycleMachine machine) => _machineRepo.CreateRecycleMachine(machine);

        public IQueryable<RecycleMachine> GetAllRecycleMachine() => _machineRepo.GetAllRecycleMachine();

        public Task<RecycleMachine> GetRecycleMachineByID(Guid id) => _machineRepo.GetRecycleMachineByID(id);

        public Task<bool> RemoveRecycleMachine(Guid id) => _machineRepo.RemoveRecycleMachine(id);

        public Task UpdateRecycleMachine(RecycleMachineUpdateDTO machine, Guid id) => _machineRepo.UpdateRecycleMachine(machine, id);

    }
}
