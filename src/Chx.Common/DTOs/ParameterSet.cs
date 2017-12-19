using System.Collections.Generic;

namespace Chx.Common.DTOs
{
    public class ParameterSet
    {
        public string Name { get; set; }
        public List<KeyValuePair<string,string>> Parameters { get; set; }

        public ParameterSet()
        {
            Parameters = new List<KeyValuePair<string, string>>();
        }
    }
}
