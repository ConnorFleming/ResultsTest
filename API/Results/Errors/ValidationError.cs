using FluentResults;

namespace API.Results.Errors;

public class ValidationError : IError
{
    public string PropertyName { get; }
    public string Message { get; }
    public string ErrorCode { get; }
    
    
    public ValidationError(string error, string message, string propertyName)
    {
        Message = message;
        ErrorCode = error;
        PropertyName = propertyName;
    }


    // disused
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}