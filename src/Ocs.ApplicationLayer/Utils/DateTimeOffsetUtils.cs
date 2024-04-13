using System.Globalization;
using Ocs.ApplicationLayer.Exceptions;

namespace Ocs.ApplicationLayer.Utils;

public static class DateTimeOffsetUtils
{
    /// <summary>
    /// Метод для парсинга даты в виде строки из query параметра в формате "yyyy-MM-dd HH:mm:ss.ff"
    /// </summary>
    /// <param name="value">Строка даты</param>
    /// <returns>Флаг успешности парсинга</returns>
    public static DateTimeOffset ParseFromQueryParam(string value)
    {
        const string format = "yyyy-MM-dd HH:mm:ss.ff";

        value = value.Trim('"');

        var isSuccess = DateTimeOffset.TryParseExact(value, format,
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

        if (!isSuccess)
        {
            throw new IncorrectDateTimeFormatException($"Неверный формат даты. Используйте формат: {format}");
        }

        return date;
    }
}