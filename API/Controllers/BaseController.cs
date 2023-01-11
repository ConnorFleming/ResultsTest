using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Results.Errors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IActionResult HandleResult<T>(Result<T>? result)
    {
        if (result == null)
        {
            return NotFound();
        }

        if (result.HasError<ValidationError>())
        {
            return BadRequest(result.Errors.OfType<ValidationError>().ToList());
        }

        if (result.HasError<BaseError>())
        {
            return BadRequest(result.Errors.OfType<BaseError>().ToList());
        }

        return result.IsSuccess switch
        {
            true when result.Value != null => Ok(result.Value),
            true when result.Value == null => NotFound(),
            _ => BadRequest(),
        };
    }
        
    protected IActionResult HandleResult(Result result)
    {
        if (result.HasError<ValidationError>())
        {
            return BadRequest(result.Errors.OfType<ValidationError>().ToList());
        }


        if (result.HasError<BaseError>())
        {
            return BadRequest(result.Errors.OfType<BaseError>().ToList());
        }
        
        return result.IsSuccess ? Ok() : BadRequest();
    }
    
    
}

