using Ocs.ApplicationLayer.Applications;
using Ocs.Domain.Users;

namespace Ocs.ApplicationLayer.Users;

/// <summary>
/// ДТО пользователя
/// </summary>
public class UserView
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Фабрика для создания ДТО из доменной модели
    /// </summary>
    /// <param name="user">Доменная модель пользователя</param>
    /// <returns>ДТО пользотеля</returns>
    public static UserView Create(User user)
    {
        return new UserView
        {
            Id = user.Id,
            Name = user.Name.Value
        };
    }
}