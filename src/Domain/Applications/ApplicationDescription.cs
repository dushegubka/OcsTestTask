using Domain.Utils;

namespace Domain.Applications;

/// <summary>
/// Описание заявки
/// </summary>
public class ApplicationDescription
{
    private ApplicationDescription(string? value)
    {
        Value = value;
    }

    /// <summary>
    /// Текст описания 
    /// </summary>
    public string? Value { get; private set; }
    
    /// <summary>
    /// Метод изменения значения
    /// </summary>
    /// <param name="value">Обновленное описание</param>
    public void ChangeValue(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 300);
        
        Value = value;
    }

    public static ApplicationDescription Create(string? value)
    {
        StringValidatorUtils.ValidateStringValue(value, 300);
        
        return new ApplicationDescription(value);
    }
}