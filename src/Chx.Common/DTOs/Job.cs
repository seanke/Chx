using System.Collections.Generic;

namespace Chx.Common.DTOs
{
    public enum JobStatus
    {
        Unknown,
        None,
        Scheduled,
        Ready,
        Active,
        Success,
        Failed,
        Crashed
    }

    public class Job
    {
        public JobStatus JobStatus { get; set; }
        public Activity Activity { get; set; }
        public List<LogEntry> LogEntries { get; set; }

        public Job()
        {
            LogEntries = new List<LogEntry>();
        }
    }
}
