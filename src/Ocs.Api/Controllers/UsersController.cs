using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Views.Applications;

namespace Ocs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public UsersController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    
    [HttpGet]
    [Route("{authorId:guid}/currentapplication")]
    public async Task<ActionResult<ApplicationView>> GetCurrentUnsubmittedAsync(
        Guid authorId,
        CancellationToken cancellationToken)
    {
        var result = await _applicationService.GetUserDraftApplication(authorId, cancellationToken);
        
        return Ok(result);
    }
}