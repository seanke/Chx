using System;
using System.Collections.Generic;

namespace Chx.Common.Run
{
    public class ActivityParameterSet
    {
        public string Name { get; set; }
        public List<ActivityParameter> Parameters { get; set; }

        public ActivityParameterSet()
        {
            Parameters = new List<ActivityParameter>();
        }

        public List<string> GetParameterValues(string ParameterName)
        {
            var values = new List<string>();
            Parameters.FindAll(x => x.Name.Trim().Equals(ParameterName.Trim(), StringComparison.OrdinalIgnoreCase)).ForEach(x=>values.Add(x.Value));
            return values;
        }

        public string GetFirstParameterValue(string ParameterName)
        {
            var parameter = Parameters.Find(x => x.Name.Trim().Equals(ParameterName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (parameter != null)
                return parameter.Value;
            else
                return null;
        }
    }
}
