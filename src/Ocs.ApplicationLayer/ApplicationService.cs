using Ocs.ApplicationLayer.Abstractions;
using Ocs.ApplicationLayer.Abstractions.Services;
using Ocs.ApplicationLayer.Exceptions;
using Ocs.ApplicationLayer.Utils;
using Ocs.ApplicationLayer.Views;
using Ocs.ApplicationLayer.Views.Applications;
using Ocs.Domain.Applications;
using Ocs.Infrastructure.Extensions;

namespace Ocs.ApplicationLayer;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _repository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _repository = applicationRepository;
    }
    
    /// <inheritdoc />
    public async Task<ApplicationView?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            throw new ApplicationNotFoundException(id, "Заявка не найдена");
        }

        return ApplicationView.Create(application);
    }

    /// <summary>
    /// Метод для создания заявки
    /// </summary>
    /// <param name="newApplication">Новая заявка</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Созданная заявка</returns>
    /// <exception cref="UserAlreadyHasDraftApplicationException">Выбрасывается в случае, если пользователь с переданным идентификатором не существует</exception>
    /// <exception cref="UserNotFoundException">Выбрасывается в случае, если пользователь уже имеет черновик заявки</exception>
    public async Task<ApplicationView?> CreateAsync(ApplicationCreateView newApplication, CancellationToken cancellationToken = default)
    {
        if (_repository.UserHasDraftApplication(newApplication.Author))
        {
            throw new UserAlreadyHasDraftApplicationException(newApplication.Author, "У пользователя уже есть черновик заявки");
        }
        
        var application = Application.Create(
            Guid.NewGuid(), 
            newApplication.Author,
            newApplication.Activity,
            newApplication.Name,
            newApplication.Description,
            newApplication.Outline,
            createdAt: DateTimeOffset.UtcNow);
        
        var result = await _repository.CreateAsync(application, cancellationToken);
        
        return ApplicationView.Create(result);
    }

    /// <summary>
    /// Метод обновления заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="updatedApplication">Обновленная заявка</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Измененный объект заявки</returns>
    /// <exception cref="SubmittedApplicationEditingException">Выбрасывается в случае попытки изменить уже подтвержденную заявку</exception>
    public async Task<ApplicationView?> UpdateAsync(Guid id, ApplicationEditView updatedApplication, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            throw new ApplicationNotFoundException(id, "Заявка не найдена");
        }

        if (application.IsSubmitted)
        {
            throw new SubmittedApplicationEditingException(application.Id, 
                "Редактирование отправленных на рассмотрение заявок запрещено");
        }
        
        application.ChangeActivityType(updatedApplication.Activity);
        application.ChangeName(updatedApplication.Name);
        application.ChangeDescription(updatedApplication.Description);
        application.ChangeOutline(updatedApplication.Outline);
        
        var result = await _repository.UpdateAsync(application, cancellationToken);
        
        return ApplicationView.Create(result);
        
    }

    /// <summary>
    /// Метод удаления заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Флаг успешности удаления</returns>
    /// <exception cref="SubmittedApplicationDeletingException">Выбрасывается при попытке удалить уже подтвержденную заявку</exception>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);
        
        if (application is null)
        {
            throw new ApplicationNotFoundException(id, "Заявка не найдена");
        }

        if (application.IsSubmitted)
        {
            throw new SubmittedApplicationDeletingException(application.Id, 
                "Удаление отправленных на рассмотрение заявок запрещено");
        }
        
        return await _repository.DeleteAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetByIdAsync(id, cancellationToken);

        if (application is null)
        {
            throw new ApplicationNotFoundException(id, "Заявка не найдена");
        }
        
        return await _repository.SubmitAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ApplicationView>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _repository.GetSubmittedAfterAsync(date, cancellationToken);
        
        return applications.Select(ApplicationView.Create);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ApplicationView>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default)
    {
        var applications = await _repository.GetUnsubmittedOlderAsync(date, cancellationToken);
        
        return applications.Select(ApplicationView.Create);
    }

    public async Task<IEnumerable<ApplicationView>> FilterAsync(ApplicationFilterModel filterModel, CancellationToken cancellationToken = default)
    {
        if (filterModel.SubmittedAfter is not null && filterModel.UnsubmittedOlder is not null)
        {
            throw new ApplicationFiltrationException("Можно задать только один параметр фильтра");
        }

        if (filterModel.SubmittedAfter is not null)
        {
            var submittedAfter = DateTimeOffsetUtils.ParseFromQueryParam(filterModel.SubmittedAfter);
            return await GetSubmittedAfterAsync(submittedAfter, cancellationToken);
        }

        if (filterModel.UnsubmittedOlder is not null)
        {
            var unsubmittedOlder = DateTimeOffsetUtils.ParseFromQueryParam(filterModel.UnsubmittedOlder);
            return await GetUnsubmittedOlderAsync(unsubmittedOlder, cancellationToken);
        }

        throw new ApplicationFiltrationException("Не задан параметр фильтрации");
    }

    public async Task<ApplicationView?> GetUserDraftApplication(Guid authorId, CancellationToken cancellationToken = default)
    {
        var application = await _repository.GetUserDraftApplicationAsync(authorId, cancellationToken);

        return application is null ? null : ApplicationView.Create(application);
    }
}