using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

/// <summary>
/// Описание заявки. Необязательный параметр
/// </summary>
public class ApplicationDescription
{
    private ApplicationDescription(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Текст описания 
    /// </summary>
    public string? Value { get; private set; }

    
    public static ApplicationDescription Create(string? value)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, 300);
        
        return new ApplicationDescription(value);
    }
}