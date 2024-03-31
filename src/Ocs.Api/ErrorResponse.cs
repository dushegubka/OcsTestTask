using Microsoft.AspNetCore.Mvc;

namespace Ocs.Api;

public class ErrorResponse
{
    public string Message { get; init; }

    public int StatusCode { get; init; }

    public ProblemDetails Details { get; init; }
}