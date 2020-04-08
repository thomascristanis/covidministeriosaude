using System.Collections.Generic;
using CoronaAPI.Model;

namespace CoronaAPI.Interface
{
    public interface IClient
    {
        IList<Casos> ObterTodosCasos();
    }
}