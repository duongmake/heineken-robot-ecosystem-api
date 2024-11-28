using HeinekenRobotAPI.DataAccess;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;
using HeinekenRobotAPI.Repository.IRepo;

namespace HeinekenRobotAPI.Repository.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDAO _userDao;
        public UserRepository()
        {
            _userDao = new UserDAO();
        }

        public async Task CreateUser(User user)
        {
            try
            {
                await _userDao.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<User> GetAllUser()
        {
            try
            {
                var users = _userDao.GetAll();

                if (users != null)
                {
                    return users;
                }
                throw new Exception("User not found.");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<User> GetUserByID(Guid id)
        {
            try
            {
                return _userDao.GetByID(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> RemoveUser(Guid id)
        {
            try
            {
                return await _userDao.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(UserUpdateDTO user, Guid id)
        {
            try
            {
                var existUser = await _userDao.GetByID(id);
                if (existUser != null)
                {
                    if (!string.IsNullOrEmpty(user.UserName))
                    {
                        existUser.UserName = user.UserName;
                    }
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        existUser.Password = user.Password;
                    }
                    if (!string.IsNullOrEmpty(user.FullName))
                    {
                        existUser.FullName = user.FullName;
                    }
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        existUser.Email = user.Email;
                    }
                    if (!string.IsNullOrEmpty(user.Role))
                    {
                        existUser.Role = user.Role;
                    }

                    await _userDao.Update(existUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
