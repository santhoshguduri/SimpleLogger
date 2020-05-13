using System;
using SimpleLogger.Services;
using System.Reflection;

namespace SimpleLogger.Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            Type Logger = MethodBase.GetCurrentMethod().DeclaringType;

            Console.WriteLine("Hello World!");

            LogService service = new LogService("Connection_String",Logger);
            
            service.LogDebug("Hi All!");

            int a = 0;

            try
            {
                int b = 15;

                int c = b / a;
            }
            catch(Exception ex)
            {
                service.LogError("Divided by Zero again!", ex);
            }
            Console.ReadKey();
        }
    }
}
