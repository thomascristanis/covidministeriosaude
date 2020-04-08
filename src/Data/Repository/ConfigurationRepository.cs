using Dapper;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CoronaAPI.Data.Repository
{
    public class ConfigurationRepository : IRepository<ConfigurationSystem>
    {
        private readonly IConfiguration _configuration;
        public ConfigurationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Add(ConfigurationSystem entity)
        {
            string sqlQuery = "INSERT INTO ConfigurationSystem (URL, ReferenceDate, InsertionDate) VALUES (@URL, @ReferenceDate, @InsertionDate)";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                int rowsAffected = connection.Execute(sqlQuery, entity);
            }
        }

        public ConfigurationSystem GetFirst()
        {
            string sql = "SELECT TOP 1 * FROM ConfigurationSystem (NOLOCK) ORDER BY 1 DESC";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.QueryFirstAsync<ConfigurationSystem>(sql).Result;
            }
        }

        public IEnumerable<ConfigurationSystem> GetAll()
        {
            string sql = "SELECT * FROM ConfigurationSystem (NOLOCK) ORDER BY 1 DESC";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.QueryAsync<ConfigurationSystem>(sql).Result.ToList();
            }
        }

        public ConfigurationSystem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ConfigurationSystem entity)
        {
            throw new NotImplementedException();
        }
    }
}