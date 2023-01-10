﻿using FluentResults;
using FluentValidation;
using MediatR;

namespace API.Mediator;

public class RegisterCommand : IRequest<Result>
{
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }
    public string Confirm { get; }
    
    public RegisterCommand(string username, string email, string password, string confirm)
    {
        Username = username;
        Email = email;
        Password = password;
        Confirm = confirm;
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (request.Username == "test")
        {
            return Result.Fail("");
        }

        if (request.Password != request.Confirm)
        {
            return Result.Fail("");
        }

        if (true)
        {
            return Result.Ok().WithSuccess("hola");
        }

        return Result.Ok();
    }
}

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        
    }
}