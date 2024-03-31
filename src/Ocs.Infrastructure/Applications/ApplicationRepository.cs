using Microsoft.EntityFrameworkCore;
using Ocs.Domain.Applications;
using Ocs.Infrastructure.Extensions;

namespace Ocs.Infrastructure.Applications;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationDbContext _database;

    public ApplicationRepository(ApplicationDbContext applicationDbContext)
    {
        _database = applicationDbContext;
    }
    
    public async Task<Application?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var applicationEntity = await _database.Applications
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        var result = applicationEntity?.ToDomainModel();

        return result;
    }

    public async Task<Application?> CreateAsync(Application application, CancellationToken cancellationToken = default)
    {
        await _database.Applications.AddAsync(application.ToDatabaseEntity(), cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);
        
        return application;
    }

    public async Task<Application?> UpdateAsync(Application application, CancellationToken cancellationToken = default)
    {
        var existingApplication = await _database.Applications
            .SingleOrDefaultAsync(x => x.Id == application.Id, cancellationToken);
        
        if (existingApplication is null)
        {
            return null;
        }
        
        _database.Entry(existingApplication).CurrentValues.SetValues(application.ToDatabaseEntity());
        
        await _database.SaveChangesAsync(cancellationToken);
        
        return application;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _database.Applications
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (application is null)
        {
            return false;
        }
        
        _database.Applications.Remove(application);
        await _database.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    public async Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _database.Applications
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (application is null)
        {
            return false;
        }
        
        var appDomain = application.ToDomainModel();
        
        appDomain.Submit();
        
        _database.Entry(application).CurrentValues.SetValues(appDomain.ToDatabaseEntity());
        
        await _database.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    public async Task<IEnumerable<Application>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _database.Applications
            .Where(x => x.SubmittedAt > date).ToListAsync(cancellationToken);
        
        return applications.Select(x => x.ToDomainModel());
    }

    public async Task<IEnumerable<Application>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _database.Applications
            .Where(x => x.CreatedAt < date && !x.IsSubmitted)
            .ToListAsync(cancellationToken);
        
        return applications.Select(x => x.ToDomainModel());
    }
}