using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaAPI.CSV;
using CoronaAPI.Data;
using CoronaAPI.Interface;
using CoronaAPI.Model;

namespace CoronaAPI.Client
{
    public class RequestAPIClient : IClient
    {
        private ConfigurationSystem _configuration;
        public RequestAPIClient(ConfigurationSystem configuration)
        {
            this._configuration = configuration;
        }
        
        public IList<Casos> ObterTodosCasos()
        {
            using (var streamReader = new StreamReader(RequestURL(_configuration.URL).Result))
            {
                ReaderCSV<Casos, CasosMap> readerCSV = new ReaderCSV<Casos, CasosMap>();
                return readerCSV.Reader(streamReader).Result;
            }
        }

        private async Task<Stream> RequestURL(string url)
        {
            using (var client = new HttpClient())
            {
                return (await client.GetStreamAsync(url));
            }
        }
    }
}