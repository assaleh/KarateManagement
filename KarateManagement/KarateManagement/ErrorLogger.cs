using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateManagement
{
    /// <summary>
    /// This class is to be used to log files so that they may be written to a file
    /// </summary>
    /// TODO Make sure its thread safe
    public class ErrorLogger
    {
        private static ErrorLogger logger;

        private ErrorLogger()
        {
        }
        
        public static ErrorLogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = new ErrorLogger();
                }
                return logger;
            }
        }

        /// <summary>
        /// Writes an error message to a log file
        /// </summary>
        /// <param name="error">A message to log</param>
        public void Write(string error)
        {
            string fileName = String.Format("ErrorLog_{0}-{1}-{2}.log", DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.Now.Day); 
            
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                String formatedError = String.Format(
                    "{0} : {1}{3}{2}{3}-------------------------------------------------",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), error, Environment.NewLine);
                file.WriteLine(formatedError);
            }
        }
    }
}
