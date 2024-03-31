using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Exceptions;
using Ocs.ApplicationLayer.Extensions;
using Ocs.ApplicationLayer.Utils;

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
    public async Task<ActionResult<ApplicationView>> CreateAsync([FromBody] ApplicationCreateView newApplication, CancellationToken cancellationToken)
    {
        var application = await _applicationService.CreateAsync(newApplication, cancellationToken);
        
        return Ok(application);
    }
    
    [HttpPost]
    [Route("{id:guid}/submit")]
    public async Task<IActionResult> SubmitAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var isSubmitted = await _applicationService.SubmitAsync(id, cancellationToken);
        
        if (!isSubmitted)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult<ApplicationView>> UpdateAsync([FromRoute] Guid id,
        [FromBody] ApplicationEditView updatedApplication,
        CancellationToken cancellationToken)
    {
        var updateResult = await _applicationService.UpdateAsync(id, updatedApplication, cancellationToken);

        if (updateResult is null)
        {
            return NotFound();
        }

        return Ok(updateResult);
    }
    
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<ApplicationView>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var application = await _applicationService.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            return NotFound();
        }
        
        return Ok(application);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationView>>> GetSubmittedAfter(
        [FromQuery] string submittedAfter, 
        CancellationToken cancellationToken)
    {
        if (!DateTimeOffsetUtils.ParseFromQueryParam(submittedAfter, out var date))
        {
            return BadRequest();
        }
        
        var result = await _applicationService.GetSubmittedAfterAsync(date, cancellationToken);
        
        return Ok(result);
    }
    
    
    [HttpGet("{unsubmittedOlder}")]
    public async Task<ActionResult<IEnumerable<ApplicationView>>> GetUnsubmittedOlder(
        string unsubmittedOlder, 
        CancellationToken cancellationToken)
    {
        if (!DateTimeOffsetUtils.ParseFromQueryParam(unsubmittedOlder, out var date))
        {
            return BadRequest();
        }
        
        var result = await _applicationService.GetUnsubmittedOlderAsync(date, cancellationToken);
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await _applicationService.DeleteAsync(id, cancellationToken);
        
        if (!isDeleted)
        {
            return NotFound();
        }
        
        return Ok();
    }
}