using Ocs.ApplicationLayer.Exceptions;
using Ocs.Domain.Applications;
using Ocs.Domain.Users;
using Ocs.Infrastructure.Applications;
using Ocs.Infrastructure.Extensions;

namespace Ocs.ApplicationLayer.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _repository;
    private readonly IUserRepository _userRepository;

    public ApplicationService(IApplicationRepository applicationRepository, IUserRepository userRepository)
    {
        _repository = applicationRepository;
        _userRepository = userRepository;
    }
    
    public async Task<ApplicationView?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);

        return ApplicationView.Create(application);
    }

    public async Task<ApplicationView?> CreateAsync(ApplicationCreateView newApplication, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(newApplication.Author, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(newApplication.Author, "Пользователь не найден");
        }
        
        if (_repository.UserHasDraftApplication(newApplication.Author))
        {
            throw new UserAlreadyHasDraftApplicationException(newApplication.Author, "У пользователя уже есть черновик заявки");
        }
        
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
        var application = await _repository.GetByIdAsync(id, cancellationToken);

        if (application is null)
        {
            return false;
        }
        
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

    public async Task<bool> UserHasDraftApplicationAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(userId, "Пользователь не найден");
        }
        
        return _repository.UserHasDraftApplication(userId);
    }
}