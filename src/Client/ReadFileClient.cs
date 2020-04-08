using System;
using System.Collections.Generic;
using System.IO;
using CoronaAPI.CSV;
using CoronaAPI.Interface;
using CoronaAPI.Model;

namespace CoronaAPI.Client
{
    public class ReadFileClient : IClient
    {
        public IList<Casos> ObterTodosCasos()
        {
            string path = formatterPathName();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("O arquivo solicitado não existe");
            }
            return ReadFile(path);
        }

        private IList<Casos> ReadFile(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream))
            {
                ReaderCSV<Casos, CasosMap> readerCSV = new ReaderCSV<Casos, CasosMap>();
                return readerCSV.Reader(streamReader).Result;
            }
        }

        private String formatterPathName()
        {
            string path = string.Empty;

            path = String.Format($"{FileProperties.directory}{Path.DirectorySeparatorChar}");
            path = ($"{path}{FileProperties.fileName}{FileProperties.formatData}{FileProperties.extension}");

            return path;
        }
    }
}