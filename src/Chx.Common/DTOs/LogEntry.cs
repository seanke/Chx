using System;
using System.Collections.Generic;

namespace Chx.Common.DTOs
{
    public enum LogEntryType
    {
        JobStarted,
        JobCompleted
    }

    public enum LogEntryLevel
    {
        Error,
        Warning,
        Infomation,
        Verbose
    }

    public class LogEntry
    {
        public DateTime DateTime { get; set; }
        public List<KeyValuePair<string, string>> Output { get; set; }

        public LogEntry()
        {
            Output = new List<KeyValuePair<string, string>>();
        }
    }
}
