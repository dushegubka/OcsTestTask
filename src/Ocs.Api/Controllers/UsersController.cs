using Microsoft.AspNetCore.Mvc;
using Ocs.ApplicationLayer.Applications;
using Ocs.ApplicationLayer.Exceptions;
using Ocs.ApplicationLayer.Users;
using Ocs.Domain.Applications;

namespace Ocs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IApplicationRepository _applicationRepository;

    public UsersController(IUserService userService, IApplicationRepository applicationRepository)
    {
        _userService = userService;
        _applicationRepository = applicationRepository;
    }

    [HttpGet]
    [Route("{userId:guid}/currentapplication")]
    public async Task<ActionResult<ApplicationView>> GetDraftApplication(
        Guid userId, CancellationToken cancellationToken)
    {
        var hasDraft = _applicationRepository.UserHasDraftApplication(userId);
        
        if (!hasDraft)
        {
            return null;
        }
        
        var application = await _applicationRepository
            .GetUserDraftApplicationAsync(userId, cancellationToken);
        
        if (application is null)
        {
            return NotFound();
        }
        
        return Ok(ApplicationView.Create(application));
    }

    [HttpPost]
    public async Task<ActionResult<UserView>> CreateUser([FromBody] UserCreateView newUser, 
        CancellationToken cancellationToken)
    {
        var result = await _userService.CreateAsync(newUser, cancellationToken);
        
        return Ok(result);
    }
}