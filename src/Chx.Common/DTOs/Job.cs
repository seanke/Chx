using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chx.Common.DTOs
{
    public enum JobType
    {
        HttpRequest,
        Process
    }

    public enum JobStatus
    {
        Unknown,
        Ready,
        Active,
        Finished,
        Crashed
    }

    public class Job
    {
        public JobType JobType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
