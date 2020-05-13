using System;
using System.Reflection;
using Xunit;
using SimpleLogger.Services;
using SimpleLogger.Model;

namespace SimpleLogger.Tests
{
    public class LogServiceTests
    {
        static Type Logger = MethodBase.GetCurrentMethod().DeclaringType;

        LogService service = new LogService("Connection_String", Logger);
        [Fact]
        public void AddLogToDataBase_ShouldWork()
        {
            string LogMessage = "This is a test message from XUnit test";

            service.LogError(LogMessage);

            Assert.Equal(LogMessage, service.Context.Logs.Find(7).LogMessage);
            Assert.Contains("XUnit", service.Context.Logs.Find(7).LogMessage);
        }

        [Fact]
        public void AddLogToDataBase_ShouldFail()
        {

            string LogMessage = "This is a test message from XUnit test";

            service.LogError(LogMessage);

            Assert.True(Logger.FullName == service.Context.Logs.Find(7).LogMode);
            
        }

        [Theory]
        [InlineData("Testing Started!")]
        public void AddLogToDataBase_UsingInlineData_ShouldWork(string logMessage)
        {
            string actual ="";

            int a = 0;

            try
            {
                int b = 15 / a;
            }
            catch(Exception ex)
            {
                actual = ex.Message;
                service.LogError(logMessage, ex);
            }

            Assert.Equal(actual, service.Context.Logs.Find(175).ExceptionMessage);
        }

    }
}
