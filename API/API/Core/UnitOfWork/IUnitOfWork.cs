using API.Core.IRepository;

namespace API.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        Task CompleteAsync();
    }
}
