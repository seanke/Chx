using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chx.Common.DTOs
{
    public enum EventType
    {
        JobStarted,
        JobCompleted
    }
    public class Event
    {
        public DateTime DateTime { get; set; }
    }
}
