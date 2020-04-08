using System.Collections.Generic;
using CoronaAPI.Model;
using System.Linq;
using System;

namespace CoronaAPI.src.Filter
{
    public class CasosCriteria : ICasosCriteria
    {
        private IEnumerable<Casos> casos;
        public CasosCriteria(IEnumerable<Casos> casos)
        {
            this.casos = casos;
        }

        public IEnumerable<Casos> PorData(string data)
        {
            if (!IsNullable(data))
            {
                var query = from c in this.casos
                            where c.Date == data
                            select c;

                return query;
            }
            else
            {
                return new List<Casos>();
            }
        }

        public IEnumerable<Casos> PorEstado(string uf)
        {
            if (!IsNullable(uf))
            {
                var query = from c in this.casos
                            where c.Sigla == uf ||
                            c.Sigla == uf.ToUpper()
                            select c;

                return query;
            }
            else
            {
                return new List<Casos>();
            }
        }

        public IEnumerable<Casos> PorRegiao(string regiao)
        {
            if (!IsNullable(regiao))
            {
                var query = from c in this.casos
                            where c.Regiao == regiao ||
                            c.Regiao == ToUpperFirst(regiao)
                            select c;
                return query;
            }
            else
            {
                return new List<Casos>();
            }
        }

        private bool IsNullable(object objeto)
        {
            if (objeto != null)
                return false;
            else
                return true;
        }

        private string ToUpperFirst(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}