using System.Collections.Generic;
using CoronaAPI.Adapter;
using CoronaAPI.Data;
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
        private UnitOfWork _unitOfWork;
        public CasosController(ILogger<CasosController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = new UnitOfWork(_configuration);
        }

        [HttpGet()]
        public IEnumerable<Casos> Get()
        {
            ConfigurationSystem config = _unitOfWork.ConfigurationSystem.GetFirst();
            CovidDisplayService displayFile = new CovidDisplayService(new APISourceCovidAdapter(config));
            return displayFile.GetAll();
        }
        
        [HttpGet("estado/{uf}")]
        public IEnumerable<Casos> GetPorEstado(string uf)
        {
            ConfigurationSystem config = _unitOfWork.ConfigurationSystem.GetFirst();
            CovidDisplayService displayFile = new CovidDisplayService(new APISourceCovidAdapter(config));
            ICasosCriteria criteria = new CasosCriteria(displayFile.GetAll());
            return criteria.PorEstado(uf);

        }
        
        [HttpGet("regiao/{regiao}")]
        public IEnumerable<Casos> GetPorRegiao(string regiao)
        {
            ConfigurationSystem config = _unitOfWork.ConfigurationSystem.GetFirst();
            CovidDisplayService displayFile = new CovidDisplayService(new APISourceCovidAdapter(config));
            ICasosCriteria criteria = new CasosCriteria(displayFile.GetAll());
            return criteria.PorRegiao(regiao);
        }

        [HttpGet("data")]
        public IEnumerable<Casos> GetPorData(DataCaso dataCaso)
        {
            ConfigurationSystem config = _unitOfWork.ConfigurationSystem.GetFirst();
            CovidDisplayService displayFile = new CovidDisplayService(new APISourceCovidAdapter(config));
            ICasosCriteria criteria = new CasosCriteria(displayFile.GetAll());
            return criteria.PorData(dataCaso.Date);
        }
    }
}