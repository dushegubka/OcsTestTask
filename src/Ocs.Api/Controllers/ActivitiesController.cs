using Microsoft.AspNetCore.Mvc;
using Ocs.Domain.Enums;

namespace Ocs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly List<ActivityView> _activities = new()
    {
        new ActivityView(ActivityType.Report, "Доклад, 35-45 минут"),
        new ActivityView(ActivityType.Masterclass, "Мастеркласс, 1-2 часа"),
        new ActivityView(ActivityType.Discussion, "Дискуссия / круглый стол, 40-50 минут"),

    };
    
    [HttpGet]
    public IEnumerable<ActivityView> Get()
    {
        return _activities;
    }
}

public record ActivityView(ActivityType Activity, string Description);