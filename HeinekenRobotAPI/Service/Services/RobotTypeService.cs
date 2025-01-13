using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using HeinekenRobotAPI.Service.IServices;

namespace HeinekenRobotAPI.Service.Services
{
    public class RobotTypeService : IRobotTypeService
    {
        private readonly IRobotTypeRepository _typeRepo;
        public RobotTypeService(IRobotTypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }

        public Task CreateRobotType(RobotType type) => _typeRepo.CreateRobotType(type);

        public IQueryable<RobotType> GetAllRobotType() => _typeRepo.GetAllRobotType();

        public Task<RobotType> GetRobotTypeByID(Guid id) => _typeRepo.GetRobotTypeByID(id);

        public Task<bool> RemoveRobotType(Guid id) => _typeRepo.RemoveRobotType(id);

        public Task UpdateRobotType(RobotTypeUpdateDTO type, Guid id) => _typeRepo.UpdateRobotType(type, id);

    }
}
