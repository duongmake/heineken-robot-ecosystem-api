using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class CampaignRobotMachineRepository : ICampaignRobotMachineRepository
    {
        private readonly ICampaignRobotMachineDAO _machineDao;
        public CampaignRobotMachineRepository()
        {
            _machineDao = new CampaignRobotMachineDAO();
        }

        public async Task CreateCampaignRobotMachine(CampaignRobotMachine machine)
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

        public IQueryable<CampaignRobotMachine> GetAllCampaignRobotMachine()
        {
            try
            {
                var machines = _machineDao.GetAll().Include(s => s.Campaign)
                                                   .Include(s => s.Robot)
                                                   .Include(s => s.RecycleMachine)
                                                   .Include(s => s.Location);
                if (machines != null)
                {
                    return machines;
                }
                throw new Exception("Campaign Robot Machine not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<CampaignRobotMachine> GetCampaignRobotMachineByID(Guid id)
        {
            try
            {
                return _machineDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveCampaignRobotMachine(Guid id)
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

        public async Task UpdateCampaignRobotMachine(CampaignRobotMachineUpdateDTO machine, Guid id)
        {
            try
            {
                var existMachine = await _machineDao.GetByID(id);
                if (existMachine != null)
                {
                    if (!string.IsNullOrEmpty(machine.Status))
                    {
                        existMachine.Status = machine.Status;
                    }
                    if (machine.AssignedDate.HasValue)
                    {
                        existMachine.AssignedDate = machine.AssignedDate.Value;
                    }
                    if (machine.CampaignId.HasValue)
                    {
                        existMachine.CampaignId = machine.CampaignId.Value;
                    }
                    if (machine.RobotId.HasValue)
                    {
                        existMachine.RobotId = machine.RobotId.Value;
                    }
                    if (machine.RecycleMachineId.HasValue)
                    {
                        existMachine.RecycleMachineId = machine.RecycleMachineId.Value;
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
