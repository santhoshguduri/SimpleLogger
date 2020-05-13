using System;
using SimpleLogger.Model;
using SimpleLogger.Data;

namespace SimpleLogger.Services
{
    public class LogService : ILogService
    {
        private readonly string Logger;

        public readonly LoggerContext Context;

        public LogService(string connectionString,Type type)
        {
            LoggerContext context = new LoggerContext(connectionString);

            Context = context;

            Logger = type.FullName;
        }

        private void LogToDatabase(string mode,string message,string exceptionMessage)
        {

            Log DbLogger = new Log()
            {
                LogDate = DateTime.Now.Date,
                LogTime = DateTime.Now.TimeOfDay,
                Logger = Logger,
                LogMode = mode,
                LogMessage = message,
                ExceptionMessage = exceptionMessage
            };

            Context.Logs.Add(DbLogger);
            Context.SaveChanges();
        }

        public void LogDebug(string message)
        {
            LogToDatabase("Debug", message, "");
        }

        public void LogError(string message)
        {
            
            LogToDatabase("Error",message,"");
        }

        public void LogError(string message, Exception exception)
        {
           
            LogToDatabase("Error",message,exception.Message);
        }

    }

}
