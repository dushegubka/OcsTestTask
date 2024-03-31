using Ocs.Domain.Utils;

namespace Ocs.Domain.Users;

public class UserName
{
    private UserName(string name)
    {
        Value = name;
    }
    
    public string Value { get; }

    public static UserName Create(string name)
    {
        StringValidatorUtils.ValidateStringValue(name, 100);
        
        return new UserName(name);
    }
}