using System.Collections.Generic;
using CoronaAPI.Adapter;
using CoronaAPI.Data;
using CoronaAPI.Data.Repository;
using CoronaAPI.Model;
using CoronaAPI.Services;
using CoronaAPI.src.Data.UoW;
using CoronaAPI.src.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoronaAPI.Controllers
{
    [ApiController]
    [Route("api/casos")]
    public class CasosController : ControllerBase
    {
        private readonly ILogger<CasosController> _logger;
        private readonly IConfiguration _configuration;
        private CovidDisplayService _displayFile;
        private ConfigurationSystem _configurationSystem;
        public CasosController(ILogger<CasosController> logger, IConfiguration configuration, IUnitOfWork unitOfWork, IRepository<ConfigurationSystem> repos)
        {
            _logger = logger;
            _configuration = configuration;
            _configurationSystem = unitOfWork.ConfigurationSystem;
            _displayFile = new CovidDisplayService(new APISourceCovidAdapter(_configurationSystem));
        }

        [HttpGet()]
        public IEnumerable<Casos> Get()
        {
            return _displayFile.GetAll();
        }
        
        [HttpGet("estado/{uf}")]
        public IEnumerable<Casos> GetPorEstado(string uf)
        {
            ICasosCriteria criteria = new CasosCriteria(_displayFile.GetAll());
            return criteria.PorEstado(uf);

        }
        
        [HttpGet("regiao/{regiao}")]
        public IEnumerable<Casos> GetPorRegiao(string regiao)
        {
            ICasosCriteria criteria = new CasosCriteria(_displayFile.GetAll());
            return criteria.PorRegiao(regiao);
        }

        [HttpGet("data")]
        public IEnumerable<Casos> GetPorData(DataCaso dataCaso)
        {
            ICasosCriteria criteria = new CasosCriteria(_displayFile.GetAll());
            return criteria.PorData(dataCaso.Date);
        }
    }
}