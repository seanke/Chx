using System.Collections.Generic;

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
        public List<ParameterSet> ParameterSets { get; set; }
        public Activity()
        {
            ParameterSets = new List<ParameterSet>();
        }
    }
}
