using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

/// <summary>
/// Value object для плана
/// </summary>
public class ApplicationOutline
{
    private ApplicationOutline(string? value)
    {
        Value = value;
    }

    /// <summary>
    /// Значение
    /// </summary>
    public string? Value { get; private set; }
    
    public static ApplicationOutline Create(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 1000);
        
        return new ApplicationOutline(value);
    }
}