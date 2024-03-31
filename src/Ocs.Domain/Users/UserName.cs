using Ocs.Domain.Utils;

namespace Ocs.Domain.Users;

/// <summary>
/// Value object для имени
/// </summary>
public class UserName
{
    private UserName(string name)
    {
        Value = name;
    }
    
    /// <summary>
    /// Значение
    /// </summary>
    public string Value { get; }

    public static UserName Create(string name)
    {
        StringValidatorUtils.ValidateStringValue(name, 100);
        
        return new UserName(name);
    }
}