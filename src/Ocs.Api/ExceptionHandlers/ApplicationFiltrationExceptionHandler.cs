using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

/// <summary>
/// Обработчик исключения <see cref="ApplicationFiltrationException"/>
/// </summary>
public class ApplicationFiltrationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ApplicationFiltrationException filtrationException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 400;

        var errorResponse = new ErrorResponse
        {
            Message = filtrationException.Message,
            StatusCode = httpContext.Response.StatusCode,
            Details = new ProblemDetails()
        };
        
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
        
        return true;
    }
}