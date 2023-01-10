using FluentResults;

namespace API.Results;

public class RegisterSuccess : Success
{
    public object SuccessValue { get; set; }
}