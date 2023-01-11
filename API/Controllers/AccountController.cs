using API.Mediator;
using API.Models;
using FluentResults;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel request)
    {
        return HandleResult(
            await Mediator.Send(new RegisterCommand(request.Username, request.Email, request.Password, request.Confirm)));
    }

    [HttpPost("NormalFailure")]
    public async Task<IActionResult> Normal()
    {
        return HandleResult(Result.Fail("This is a normal failure"));
    }
}