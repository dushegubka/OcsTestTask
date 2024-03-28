namespace Domain.Utils;

public static class StringValidatorUtils
{
    public static void ValidateStringValue(string? value, int maxLength = int.MaxValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, maxLength);
    }
}