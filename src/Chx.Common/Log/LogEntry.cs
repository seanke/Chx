using System;
using System.Collections.Generic;

namespace Chx.Common.Log
{
    public enum LogEntryType
    {
        Unknown,
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
        public List<KeyValuePair<string, string>> Messages { get; set; }

        public LogEntry()
        {
            Messages = new List<KeyValuePair<string, string>>();
        }
    }
}
