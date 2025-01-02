using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RecycleMachineRepository : IRecycleMachineRepository
    {
        private readonly IRecycleMachineDAO _machineDao;
        public RecycleMachineRepository()
        {
            _machineDao = new RecycleMachineDAO();
        }

        public async Task CreateRecycleMachine(RecycleMachine machine)
        {
            try
            {
                await _machineDao.Add(machine);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<RecycleMachine> GetAllRecycleMachine()
        {
            try
            {
                var machines = _machineDao.GetAll().Include(s => s.Location);
                if (machines != null)
                {
                    return machines;
                }
                throw new Exception("RecycleMachine not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<RecycleMachine> GetRecycleMachineByID(Guid id)
        {
            try
            {
                return _machineDao.GetByIDInclude(id, s => s.Location);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveRecycleMachine(Guid id)
        {
            try
            {
                return await _machineDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRecycleMachine(RecycleMachineUpdateDTO machine, Guid id)
        {
            try
            {
                var existMachine = await _machineDao.GetByID(id);
                if (existMachine != null)
                {
                    if (!string.IsNullOrEmpty(machine.MachineCode))
                    {
                        existMachine.MachineCode = machine.MachineCode;
                    }
                    if (!string.IsNullOrEmpty(machine.Status))
                    {
                        existMachine.Status = machine.Status;
                    }
                    if (!string.IsNullOrEmpty(machine.ContainerStatus))
                    {
                        existMachine.ContainerStatus = machine.ContainerStatus;
                    }
                    if (machine.LastServiceDate.HasValue)
                    {
                        existMachine.LastServiceDate = machine.LastServiceDate.Value;
                    }
                    if (machine.CreateTime.HasValue)
                    {
                        existMachine.CreateTime = machine.CreateTime.Value;
                    }
                    if (machine.Interaction.HasValue)
                    {
                        existMachine.Interaction = machine.Interaction.Value;
                    }
                    if (machine.LocationId.HasValue)
                    {
                        existMachine.LocationId = machine.LocationId.Value;
                    }

                    await _machineDao.Update(existMachine);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
