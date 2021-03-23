namespace Core.Validation.Interface
{
    public interface IValidationResult
    {

        bool IsValid { get; }

        string Message { get; }
    }
}