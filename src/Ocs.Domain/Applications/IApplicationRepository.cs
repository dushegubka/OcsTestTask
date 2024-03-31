namespace Ocs.Domain.Applications;

public interface IApplicationRepository
{
    Task<Application?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Application?> CreateAsync(Application application, CancellationToken cancellationToken = default);
    
    Task<Application?> UpdateAsync(Application application, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Application>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Application>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
}