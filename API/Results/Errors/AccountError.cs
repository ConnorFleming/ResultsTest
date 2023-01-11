namespace API.Results.Errors;

public class AccountError : BaseError
{
    public AccountError(EAccountError error) : base(error)
    {
    }

    protected override string GetErrorMessage(Enum error)
    {
        return error switch
        {
            EAccountError.InvalidEmail => "Email address is invalid",
            EAccountError.InvalidUsername => "Username is invalid",
            EAccountError.PasswordDoesNotMatchConfirm => "Password and confirm password do not match",
            _ => throw new ArgumentException("Invalid error provided")
        };
    }
}

public enum EAccountError
{
    InvalidEmail,
    InvalidUsername,
    PasswordDoesNotMatchConfirm
}