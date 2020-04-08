using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaAPI.CSV
{
    public class ReaderCSV<TEntity, TEntityMapping> 
    where TEntity : class
    where TEntityMapping : ClassMap
    {
        private const string delimiterCSV = ";";
        public async Task<List<TEntity>> Reader(StreamReader reader)
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                this.Setup(csv);
                return await Task.Run(() => csv.GetRecords<TEntity>().ToList<TEntity>());
            }
        }
        private void Setup(CsvReader csv)
        {
            csv.Configuration.Delimiter = delimiterCSV;
            csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
            csv.Configuration.RegisterClassMap<TEntityMapping>();
        }
    }
}