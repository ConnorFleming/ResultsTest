using API.Mediator;
using API.Models;
using FluentResults;
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
        var registerResult =
            await Mediator.Send(new RegisterCommand(request.Username, request.Email, request.Password, request.Confirm));

        if (registerResult.IsFailed)
        {
            return BadRequest(registerResult.Errors.FirstOrDefault());
        }

        if (registerResult.HasSuccess<Success>())
        {
            return Ok("different");
        }

        return Ok();
    }
}