using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

/// <summary>
/// Value object для названия
/// </summary>
public class ApplicationName
{
    private ApplicationName(string? value)
    {
        Value = value;
    }

    /// <summary>
    /// Значение
    /// </summary>
    public string? Value { get; private set; }

    public static ApplicationName Create(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 100);
        
        return new ApplicationName(value);
    }
}