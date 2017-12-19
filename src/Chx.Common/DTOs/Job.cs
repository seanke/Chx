using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chx.Common.DTOs
{
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
        public JobStatus JobStatus { get; set; }
    }
}
