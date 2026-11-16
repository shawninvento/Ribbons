namespace Ribbons.Validation
{
    public sealed class ValidationError
    {
        public string PropertyName { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}