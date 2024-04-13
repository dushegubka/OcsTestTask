namespace Ocs.Domain.Utils;

public static class StringValidatorUtils
{
    /// <summary>
    /// Проверят, что строка не пустая и не превышает максимальную длину
    /// </summary>
    /// <param name="value">Входная строка</param>
    /// <param name="maxLength">Максимальная длина строки</param>
    public static void NotNullOrWhiteSpaceAndLessThan(string? value, int maxLength = int.MaxValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, maxLength);
    }

    /// <summary>
    /// Проверяет, что строка не null и не превышает максимальную длину
    /// </summary>
    /// <param name="value">Входная строка</param>
    /// <param name="maxLength">Максимальная длина строки</param>
    public static void NotNullAndLessThan(string? value, int maxLength = int.MaxValue)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, maxLength);
    }
}