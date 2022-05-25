namespace WK.Tech.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
