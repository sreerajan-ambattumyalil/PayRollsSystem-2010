namespace PayRollSystem.Models
{
    public class Field
    {
        public Field()
        {

        }
        public Field(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public string Error { get; set; }
    }
}