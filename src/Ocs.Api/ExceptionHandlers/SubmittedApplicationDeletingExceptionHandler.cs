using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.Api.ExceptionHandlers;

public class SubmittedApplicationDeletingExceptionHandler : IExceptionHandler
{
    private const string ErrorMessage = "Удаление отправленных на рассмотрение заявок запрещено";
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not SubmittedApplicationDeletingException editingException)
        {
            return false;
        }
        
        httpContext.Response.StatusCode = 422;
        
        var problemDetails = new ProblemDetails();
        problemDetails.Extensions.Add("applicationId", editingException.ApplicationId);
        
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