using Chx.Common.Run;
using System.Collections.Generic;

namespace Chx.Tests.Common
{
    public static class Examples
    {
        public static ActivityParameterSet ActivityParameterSet_NullName => new ActivityParameterSet
        {
            Parameters = new List<ActivityParameter>() {
                new ActivityParameter() {Name = "MyParameter", Value = "1"},
                new ActivityParameter() {Name = "AnoTHER_ONE", Value = "2"},
                new ActivityParameter() {Name = "Another_ONE", Value = "3"},
                new ActivityParameter() {Name = "LAstONE", Value = "4"}
            }
        };
    }
}
