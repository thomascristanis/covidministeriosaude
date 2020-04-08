using System;

namespace CoronaAPI.Client
{
    public class FileProperties
    {
        public static string formatData = DateTime.Now.ToString("ddMM");
        public static string directory = "data";
        public static string fileName = "covid";
        public static string extension = ".csv";   
    }
}