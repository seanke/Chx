using System.Collections.Generic;

namespace Chx.Common.Run
{
    public class Activity
    {
        public string Name { get; set; }
        public List<ActivityParameterSet> ParameterSets { get; set; }
        public ActivityType ActivityType { get; set; }
        public Activity()
        {
            ParameterSets = new List<ActivityParameterSet>();
        }
    }
}
