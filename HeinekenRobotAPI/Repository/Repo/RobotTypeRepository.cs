using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class RobotTypeRepository : IRobotTypeRepository
    {
        private readonly IRobotTypeDAO _typeDao;
        public RobotTypeRepository()
        {
            _typeDao = new RobotTypeDAO();
        }

        public async Task CreateRobotType(RobotType type)
        {
            try
            {
                await _typeDao.Add(type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<RobotType> GetAllRobotType()
        {
            try
            {
                var types = _typeDao.GetAll();
                if (types != null)
                {
                    return types;
                }
                throw new Exception("RobotType not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<RobotType> GetRobotTypeByID(Guid id)
        {
            try
            {
                return _typeDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveRobotType(Guid id)
        {
            try
            {
                return await _typeDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRobotType(RobotTypeUpdateDTO type, Guid id)
        {
            try
            {
                var existType = await _typeDao.GetByID(id);
                if (existType != null)
                {
                    if (!string.IsNullOrEmpty(type.RobotTypeName))
                    {
                        existType.RobotTypeName = type.RobotTypeName;
                    }

                    await _typeDao.Update(existType);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
