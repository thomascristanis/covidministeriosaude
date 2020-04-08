using System;
using System.Collections.Generic;
using CoronaAPI.Model;

namespace CoronaAPI.src.Filter
{
    public interface ICasosCriteria
    {
        IEnumerable<Casos> PorRegiao(string regiao);
        IEnumerable<Casos> PorEstado(string uf);
        IEnumerable<Casos> PorData(string data);
    }
}