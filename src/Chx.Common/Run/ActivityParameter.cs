namespace Chx.Common.Run
{
    public class ActivityParameter
    {
        public ActivityParameter()
        {
                
        }

        public ActivityParameter(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
