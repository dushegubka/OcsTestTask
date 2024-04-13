using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

/// <summary>
/// Обработчик исключения <see cref="IncorrectDateTimeFormatException"/>
/// </summary>
public class IncorrectDateTimeFormatExceptionHandler : IExceptionHandler
{
    private const string ErrorMessage = "Неверный формат даты";
    const string format = "yyyy-MM-dd HH:mm:ss.ff";

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not IncorrectDateTimeFormatException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 400;

        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("expectedFormat", format);
        
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