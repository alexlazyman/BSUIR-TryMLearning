namespace TryMLearning.Model.Validation
{
    public class ValidationError
    {
        public ValidationError(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}