namespace DomainTestWebApi.Validators
{
    public static class ValidationErrorMessages
    {
        public const string NullModelErrorMessage = "Property cannot be null";
        public const string EmptyModelErrorMessage = "Property cannot be empty";
        public const string IntRangeErrorMessage = "Value for property should be between 0..255";
    }
}