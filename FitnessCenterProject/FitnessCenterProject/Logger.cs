using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenterProject
{
    internal class Logger
    {
        static string LogFilePath = "log.txt";

        public static void LogError(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(LogFilePath, true))
            {
                sw.WriteLine("******************************************************");
                sw.WriteLine($"Exception Occured at {DateTime.Now} : {ex.Message}");
                sw.WriteLine($"Details: {ex.StackTrace}");
                sw.WriteLine("******************************************************");
            }
        }

        public static void LogError(string message)
        {
            using (StreamWriter sw = new StreamWriter(LogFilePath, true))
            {
                sw.WriteLine($"Error Occured at {DateTime.Now} : {message}");
            }

        }
    }
}
