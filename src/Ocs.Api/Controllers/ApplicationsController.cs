using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Views.Applications;

namespace Ocs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost]
    public async Task<ActionResult<ApplicationView>> CreateAsync([FromBody] ApplicationCreateView newApplication,
        CancellationToken cancellationToken)
    {
        var application = await _applicationService.CreateAsync(newApplication, cancellationToken);

        return Ok(application);
    }

    [HttpPost]
    [Route("{id:guid}/submit")]
    public async Task<IActionResult> SubmitAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _applicationService.SubmitAsync(id, cancellationToken);

        return Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<ApplicationView>> UpdateAsync(
        [FromRoute] Guid id,
        [FromBody] ApplicationEditView updatedApplication,
        CancellationToken cancellationToken)
    {
        var updateResult = await _applicationService.UpdateAsync(id, updatedApplication, cancellationToken);

        return Ok(updateResult);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<ApplicationView>> GetByIdAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var application = await _applicationService.GetByIdAsync(id, cancellationToken);

        return Ok(application);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationView>>> GetFilteredAsync(
        [FromQuery] ApplicationFilterModel filterModel,
        CancellationToken cancellationToken)
    {
        var result = await _applicationService.FilterAsync(filterModel, cancellationToken);
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _applicationService.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}