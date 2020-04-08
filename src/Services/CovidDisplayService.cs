using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoronaAPI.Model;
using CoronaAPI.Adapter;

namespace CoronaAPI.Services
{
    public class CovidDisplayService
    {
        private ISourcesCovidAdapter adapter;

        public CovidDisplayService(ISourcesCovidAdapter adapter)
        {
            this.adapter = adapter;
        }

        public void ShowData()
        {
            Console.Write(GetAll());
        }

        public IEnumerable<Casos> GetAll()
        {
            return adapter.ObterTodosCasos().AsEnumerable();
        }
        
        public String GetDataString()
        {
            IList<Casos> elementos = adapter.ObterTodosCasos();

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach (Casos caso in elementos)
            {
                sb.Append("{");
                sb.Append(String.Format("\"regiao\": \"{0}\", ", caso.Regiao));
                sb.Append(String.Format("\"sigla\": \"{0}\",", caso.Sigla));
                sb.Append(String.Format("\"date\": \"{0}\",", caso.Date));
                sb.Append(String.Format("\"casosnovos\": \"{0}\",", caso.CasosNovos));
                sb.Append(String.Format("\"casosacumulados\": \"{0}\",", caso.CasosAcumulados));
                sb.Append(String.Format("\"obitosnovos\": \"{0}\",", caso.ObitosNovos));
                sb.Append(String.Format("\"obitosacumulados\": \"{0}\"", caso.ObitosAcumulados));
                sb.Append("}");

                sb.Append(caso != elementos.Last() ? "," : string.Empty);
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}