using System;

namespace CoronaAPI.Data
{
    public class ConfigurationSystem 
    {
        public int ID { get; set; }
        public String URL { get; set; }
        public DateTime ReferenceDate { get; set; }
        public DateTime InsertionDate { get; set; }
    }
}