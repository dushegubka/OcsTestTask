using Ocs.Infrastructure.Applications;

namespace Ocs.ApplicationLayer.Applications;

public interface IApplicationService
{
    Task<ApplicationView?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<ApplicationView?> CreateAsync(ApplicationCreateView newApplication, CancellationToken cancellationToken = default);
    
    Task<ApplicationView?> UpdateAsync(Guid id, ApplicationEditView updatedApplication, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ApplicationView>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ApplicationView>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
}