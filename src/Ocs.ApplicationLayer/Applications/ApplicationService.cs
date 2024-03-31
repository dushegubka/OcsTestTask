using Ocs.ApplicationLayer.Exceptions;
using Ocs.Domain.Applications;
using Ocs.Infrastructure.Applications;
using Ocs.Infrastructure.Extensions;

namespace Ocs.ApplicationLayer.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _repository;

    public ApplicationService(IApplicationRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ApplicationView?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);

        return ApplicationView.Create(application);
    }

    public async Task<ApplicationView?> CreateAsync(ApplicationCreateView newApplication, CancellationToken cancellationToken = default)
    {
        var application = Application.Create(
            Guid.NewGuid(), 
            newApplication.Author,
            newApplication.Activity,
            ApplicationName.Create(newApplication.Name),
            ApplicationDescription.Create(newApplication.Description),
            ApplicationOutline.Create(newApplication.Outline),
            createdAt: DateTimeOffset.UtcNow);
        
        var result = await _repository.CreateAsync(application, cancellationToken);
        
        return ApplicationView.Create(result);
    }

    public async Task<ApplicationView?> UpdateAsync(Guid id, ApplicationEditView updatedApplication, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            return null;
        }

        if (application.IsSubmitted)
        {
            throw new SubmittedApplicationEditingException(application.Id, 
                "Редактирование отправленных на рассмотрение заявок запрещено");
        }
        
        application.ChangeActivityType(updatedApplication.Activity);
        application.ChangeName(ApplicationName.Create(updatedApplication.Name));
        application.ChangeDescription(ApplicationDescription.Create(updatedApplication.Description));
        application.ChangeOutline(ApplicationOutline.Create(updatedApplication.Outline));
        
        var result = await _repository.UpdateAsync(application, cancellationToken);
        
        return ApplicationView.Create(result);
        
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            return false;
        }

        if (application.IsSubmitted)
        {
            throw new SubmittedApplicationDeletingException(application.Id, 
                "Удаление отправленных на рассмотрение заявок запрещено");
        }
        
        return await _repository.DeleteAsync(id, cancellationToken);
    }

    public async Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.SubmitAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<ApplicationView>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _repository.GetSubmittedAfterAsync(date, cancellationToken);
        
        return applications.Select(ApplicationView.Create);
    }

    public async Task<IEnumerable<ApplicationView>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _repository.GetUnsubmittedOlderAsync(date, cancellationToken);
        
        return applications.Select(ApplicationView.Create);
    }
}