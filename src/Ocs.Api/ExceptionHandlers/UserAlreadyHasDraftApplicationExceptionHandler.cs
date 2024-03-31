using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

public class UserAlreadyHasDraftApplicationExceptionHandler : IExceptionHandler
{
    private const string ErrorMessage = "Пользователь уже имеет неотправленную заявку";
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not UserAlreadyHasDraftApplicationException userException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 409;

        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("userId", userException.UserId);
        
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