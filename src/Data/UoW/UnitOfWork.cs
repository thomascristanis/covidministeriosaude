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

        private ConfigurationSystem _configurationSystem;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ConfigurationSystem ConfigurationSystem
        {
            get
            {
                return _configurationSystem ??
                    (_configurationSystem = new ConfigurationRepository(_configuration).GetFirst());
            }
        }
        
        public IRepository<ConfigurationSystem> RepositoryConfigurationSystem
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