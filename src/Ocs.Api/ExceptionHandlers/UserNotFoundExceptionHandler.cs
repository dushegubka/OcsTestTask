using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

/// <summary>
/// Обработчик исключения UserNotFoundException
/// </summary>
public class UserNotFoundExceptionHandler : IExceptionHandler
{
    private const string ErrorMessage = "Пользователь не найден";
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not UserNotFoundException editingException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 404;
        
        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("userId", editingException.UserId);
        
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