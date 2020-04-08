using System.Collections.Generic;
using CoronaAPI.Client;
using CoronaAPI.Data;
using CoronaAPI.Model;

namespace CoronaAPI.Adapter
{
    public class APISourceCovidAdapter : ISourcesCovidAdapter
    {
        private ConfigurationSystem _configuration;
        public APISourceCovidAdapter(ConfigurationSystem configuration)
        {
            this._configuration = configuration;
        }
        public IList<Casos> ObterTodosCasos()
        {
            return new RequestAPIClient(_configuration).ObterTodosCasos();
        }
    }
}