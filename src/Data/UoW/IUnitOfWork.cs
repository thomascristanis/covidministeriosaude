using CoronaAPI.Data;
using CoronaAPI.Data.Repository;

namespace CoronaAPI.src.Data.UoW
{
    public interface IUnitOfWork
    {
          IRepository<ConfigurationSystem> ConfigurationSystem { get; }
          void Commit();
    }
}