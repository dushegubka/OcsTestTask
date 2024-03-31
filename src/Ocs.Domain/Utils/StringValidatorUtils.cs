namespace Ocs.Domain.Utils;

public static class StringValidatorUtils
{
    /// <summary>
    /// Метод для валидации строковых свойств
    /// </summary>
    /// <param name="value">Входная строка</param>
    /// <param name="maxLength">Максимальная длина строки</param>
    public static void ValidateStringValue(string? value, int maxLength = int.MaxValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, maxLength);
    }
}