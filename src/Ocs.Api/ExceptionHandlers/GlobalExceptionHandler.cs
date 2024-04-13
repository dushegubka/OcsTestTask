using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ocs.Api.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    const string ErrorMessage = "Internal Server Error";
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        var errorResponse = new ErrorResponse
        {
            Message = ErrorMessage,
            Details = new ProblemDetails(),
            StatusCode = httpContext.Response.StatusCode
        };
        
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
        
        return true;
    }
}