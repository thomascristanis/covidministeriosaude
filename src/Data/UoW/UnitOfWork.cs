using CoronaAPI.Data;
using CoronaAPI.Data.Repository;
using CoronaAPI.Model;
using Microsoft.Extensions.Configuration;

namespace CoronaAPI.src.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        private IRepository<ConfigurationSystem> _respositoryConfiguration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IRepository<ConfigurationSystem> ConfigurationSystem
        {
            get
            {
                return _respositoryConfiguration ??
                    (_respositoryConfiguration = new ConfigurationRepository(_configuration));
            }
        }

        public void Commit()
        {
            _respositoryConfiguration.SaveChanges();
        }
    }
}