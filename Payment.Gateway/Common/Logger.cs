
using System.IO;
using System.Reflection;
using System;
namespace Payment.Gateway.Common
{
    public class Logger
    {
        public static void LogMissingInfo(string logPath, string partfileName, string message)
        {
            string strAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            logPath = Path.Combine(strAssemblyPath, logPath);

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            string logFilePath = Path.Combine(logPath, String.Format("{0}_{1}.log", partfileName, String.Format("{0:MMddyyyy}", DateTime.Now.Date)));

            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.Write("[" + DateTime.Now + "] ");
                sw.Write("[" + partfileName + "] ");
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
}
