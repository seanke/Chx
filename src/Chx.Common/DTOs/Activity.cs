using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chx.Common.DTOs
{
    public enum ActivityType
    {
        HttpTest,
        ProcessTest
    }
    public class Activity
    {
        public string Name { get; set; }
    }
}
