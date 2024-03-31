namespace Ocs.Domain.Applications;

/// <summary>
/// Репозиторий для работы с Application
/// </summary>
public interface IApplicationRepository
{
    /// <summary>
    /// Метод получения заявки по идентификатору
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<Application?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для создания заявки в базе данных
    /// </summary>
    /// <param name="application">Объект заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Созданная заявка</returns>
    Task<Application?> CreateAsync(Application application, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для обновления данных заявки
    /// </summary>
    /// <param name="application">Объект заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Обновленная заявка</returns>
    Task<Application?> UpdateAsync(Application application, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод удаления заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Флаг успешности удаления</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для подтверждения заявки
    /// </summary>
    /// <param name="id">Id заявки</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Флаг успешности подтверждения</returns>
    Task<bool> SubmitAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод получения подтвержденных заявок после определенной даты
    /// </summary>
    /// <param name="date">Дата после которой нужно получить</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Список заявок</returns>
    Task<IEnumerable<Application>> GetSubmittedAfterAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод получения неподтвержденных заявок старше определенной даты
    /// </summary>
    /// <param name="date">Дата до которой нужно получить</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Список заявок</returns>
    Task<IEnumerable<Application>> GetUnsubmittedOlderAsync(DateTimeOffset date, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод получения черновика заявления пользователя
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Черновик заявления</returns>
    Task<Application?> GetUserDraftApplicationAsync(Guid userId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод проверки наличия черновика у пользователя
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <returns>Флаг наличия</returns>
    bool UserHasDraftApplication(Guid userId);
}