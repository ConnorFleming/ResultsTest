using FluentResults;
using Newtonsoft.Json;

namespace API.Results.Errors;

public abstract class BaseError : IError
{
    public string ErrorCode { get; }
    public string Message { get; }
    
    // not used
    [JsonIgnore]
    public Dictionary<string, object> Metadata { get; }
    [JsonIgnore]
    public List<IError> Reasons { get; }

    protected BaseError(Enum error)
    {
        ErrorCode = error.ToString();
        Message = GetErrorMessage(error);
    }

    /// <summary>
    /// Set error messages for any non validation errors
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual string GetErrorMessage(Enum error)
    {
        throw new NotImplementedException("Method must be overridden for Result.Fail");
    }
}