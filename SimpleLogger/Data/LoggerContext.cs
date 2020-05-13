using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Text;
using SimpleLogger.Model;

namespace SimpleLogger.Data
{
    public class LoggerContext : DbContext
    {
        public LoggerContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Log> Logs { get; set; }
    }
}
