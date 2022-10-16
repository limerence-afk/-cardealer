using CarDealership.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarDealership.Filters;

public class RequestExceptionFilter : IExceptionFilter
{
    private readonly ILogger<RequestExceptionFilter> _logger;

    public RequestExceptionFilter(ILogger<RequestExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RequestException requestException)
        {
            if (requestException.StatusCode >= 500)
            {
                _logger.LogError(requestException,
                    "Server error {StatusCodeName} {StatusCode}",
                    requestException.StatusCode,
                    requestException.StatusCode);
            }
            else
            {
                _logger.LogWarning(requestException,
                    "User error {StatusCodeName} {StatusCode}",
                    requestException.StatusCode,
                    requestException.StatusCode);
            }
        }
        else
        {
            _logger.LogError(context.Exception, "{Message}", context.Exception.Message);
        }

        context.Result = context.Exception switch
        {
            RequestException exception => new ObjectResult(new ProblemDetails
            {
                Detail = exception.Message
            })
            {
                StatusCode = exception.StatusCode
            },
            _ => context.Result
        };
    }
}