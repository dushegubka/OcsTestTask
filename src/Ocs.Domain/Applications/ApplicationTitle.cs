using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

public class ApplicationTitle
{
    private ApplicationTitle(string? value)
    {
        Value = value;
    }

    public string? Value { get; private set; }
    
    public void ChangeValue(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 100);
        
        Value = value;
    }

    public static ApplicationTitle Create(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 100);
        
        return new ApplicationTitle(value);
    }
}