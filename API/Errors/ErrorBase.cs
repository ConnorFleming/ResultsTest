using FluentResults;

namespace API.Errors;

public abstract class ErrorBase : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
    
    // extend to return generic error, child error classes override 
    // change base controller handleresults to check if the result is errorbase 
    // if it is return the message, reasons and their message/error code 
    // if not return as usual 
    // add custom errors with error codes, test both old and new method together 
    
    // add validator pipeline behaviour middleware 
    // make it return a validation error 
    // make sure validation errors return the same as regular result.fails and return list of the validation failures and their props 
    
}