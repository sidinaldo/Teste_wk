using WK.Tech.Core.DomainObjects;

namespace WK.Tech.Core
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
