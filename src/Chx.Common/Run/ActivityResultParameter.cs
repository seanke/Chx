namespace Chx.Common.Run
{
    public class ActivityResultParameter
    {
        public ActivityResultParameter()
        {

        }

        public ActivityResultParameter(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
