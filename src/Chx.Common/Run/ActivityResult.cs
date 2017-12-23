using Chx.Common.Log;
using System.Collections.Generic;

namespace Chx.Common.Run
{
    public class ActivityResult
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public List<LogEntry> LogEntries { get; set; }
        public List<ActivityResultParameter> Parameters { get; set; }

        public ActivityResult()
        {
            LogEntries = new List<LogEntry>();
            Parameters = new List<ActivityResultParameter>();
        }
    }
}
