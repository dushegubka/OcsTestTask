using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

/// <summary>
/// Обработчик исключения <see cref="ApplicationNotFoundException"/>
/// </summary>
public class ApplicationNotFoundExceptionHandler : IExceptionHandler
{
    private const string ErrorMessage = "Заявка не найдена";
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ApplicationNotFoundException notFoundException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 404;

        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("applicationId", notFoundException.Id);
        
        var errorResponse = new ErrorResponse
        {
            Message = ErrorMessage,
            Details = problemDetails,
            StatusCode = httpContext.Response.StatusCode
        };
        
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
        
        return true;
    }
}