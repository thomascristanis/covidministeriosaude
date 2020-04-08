using CoronaAPI.Data;
using CoronaAPI.Data.Repository;

namespace CoronaAPI.src.Data.UoW
{
    public interface IUnitOfWork
    {
          IRepository<ConfigurationSystem> RepositoryConfigurationSystem { get; }

          ConfigurationSystem ConfigurationSystem { get; }
          void Commit();
    }
}