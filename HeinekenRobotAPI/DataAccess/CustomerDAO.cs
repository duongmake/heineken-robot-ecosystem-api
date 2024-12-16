using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface ICustomerDAO : IBaseDAO<Customer, Guid> { }
    public class CustomerDAO : BaseDAO<Customer, Guid>, ICustomerDAO
    {
    }
}
