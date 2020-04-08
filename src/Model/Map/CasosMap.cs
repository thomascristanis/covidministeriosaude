using CsvHelper.Configuration;

namespace CoronaAPI.Model
{
    public class CasosMap : ClassMap<Casos>
    {

        public CasosMap()
        {
            Map(m => m.Regiao).Name("regi�o");
            Map(m => m.Sigla).Name("sigla");
            Map(m => m.Date).Name("date");
            Map(m => m.CasosNovos).Name("casosNovos");
            Map(m => m.CasosAcumulados).Name("casosAcumulados");
            Map(m => m.ObitosNovos).Name("obitosNovos");
            Map(m => m.ObitosAcumulados).Name("obitosAcumulados");   
        }
    }
}