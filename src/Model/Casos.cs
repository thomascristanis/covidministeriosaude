namespace CoronaAPI.Model
{
    public class Casos
    {
        public string Regiao { get; set; }
        public string Sigla { get; set; }
        public string Date { get; set; }
        public ushort CasosNovos { get; set; }
        public ushort CasosAcumulados { get; set; }
        public ushort ObitosNovos { get; set; }
        public ushort ObitosAcumulados { get; set; }
    }
}