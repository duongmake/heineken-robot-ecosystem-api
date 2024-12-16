using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Repository.IRepo
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllCustomer();
        Task<Customer> GetCustomerByID(Guid id);
        Task CreateCustomer(Customer custonmer);
        Task UpdateCustomer(CustomerUpdateDTO custonmer, Guid id);
        Task<bool> RemoveCustomer(Guid id);
    }
}
