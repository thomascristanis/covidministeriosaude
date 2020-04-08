using System.Collections.Generic;
using CoronaAPI.Model;

namespace CoronaAPI.Adapter
{
    public interface ISourcesCovidAdapter
    {
        IList<Casos> ObterTodosCasos();
    }
}