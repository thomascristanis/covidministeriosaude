using System.Collections.Generic;
using CoronaAPI.Client;
using CoronaAPI.Model;

namespace CoronaAPI.Adapter
{
    public class FileSourceCovidAdapter : ISourcesCovidAdapter
    {
        public IList<Casos> ObterTodosCasos()
        {
            return new ReadFileClient().ObterTodosCasos();
        }
    }
}