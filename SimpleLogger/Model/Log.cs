using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleLogger.Model
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public TimeSpan LogTime { get; set; }
        public string LogMode { get; set; }
        public string Logger { get; set; }
        public string LogMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
