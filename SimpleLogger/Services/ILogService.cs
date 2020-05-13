using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Services
{
    interface ILogService
    {

        void LogDebug(string message);

        void LogError(string message);

        void LogError(string message, Exception exception);
    }
}
