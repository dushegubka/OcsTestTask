using Ocs.Domain.Utils;

namespace Ocs.Domain.Applications;

public class ApplicationOutline
{
    private ApplicationOutline(string? value)
    {
        Value = value;
    }

    public string? Value { get; private set; }
    
    public static ApplicationOutline Create(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 1000);
        
        return new ApplicationOutline(value);
    }
}