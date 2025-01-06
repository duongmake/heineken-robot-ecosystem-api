using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.DataAccess
{
    public interface ITransactionDAO : IBaseDAO<Transaction, Guid> { }
    public class TransactionDAO : BaseDAO<Transaction, Guid>, ITransactionDAO
    {
    }
}
