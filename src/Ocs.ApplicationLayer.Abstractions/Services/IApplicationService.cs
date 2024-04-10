using Ocs.ApplicationLayer.Views;
using Ocs.ApplicationLayer.Views.Applications;

namespace Ocs.ApplicationLayer.Abstractions.Services;

public interface IApplicationService
{
    /// <summary>
    /// Метод для получения заявки по идентификатору
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>ДТО заявки</returns>
    Task<ApplicationView?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для создания заявки
    /// </summary>
    /// <param name="newApplication">Новая заявка</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Созданная заявка</returns>
    Task<ApplicationView?> CreateAsync(ApplicationCreateView newApplication, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод обновления заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="updatedApplication">Обновленная заявка</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Измененный объект заявки</returns>
    Task<ApplicationView?> UpdateAsync(Guid id, ApplicationEditView updatedApplication, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод удаления заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Флаг успешности удаления</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод подтверждения заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Флаг успешности подтверждения</returns>
    Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод получения заявок, поданных после указанной даты
    /// </summary>
    /// <param name="date">Дата после которой нужно получить заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Список заявок поданных после указанной даты</returns>
    Task<IEnumerable<ApplicationView>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод получения неподтвержденных заявок старше определенной даты
    /// </summary>
    /// <param name="date">Дата до которой нужно получить</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Список заявок</returns>
    Task<IEnumerable<ApplicationView>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ApplicationView>> FilterAsync(ApplicationFilterModel filterModel, CancellationToken cancellationToken = default);
}