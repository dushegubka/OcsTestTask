using System.Globalization;

namespace Ocs.ApplicationLayer.Utils;

public static class DateTimeOffsetUtils
{
    /// <summary>
    /// Метод для парсинга даты в виде строки из query параметра в формате "yyyy-MM-dd HH:mm:ss.ff"
    /// </summary>
    /// <param name="value">Строка даты</param>
    /// <param name="result">DateTimeOffset</param>
    /// <returns>Флаг успешности парсинга</returns>
    public static bool ParseFromQueryParam(string value, out DateTimeOffset result)
    {
        const string format = "yyyy-MM-dd HH:mm:ss.ff";

        value = value.Trim('"');

        var parseResult = DateTimeOffset.TryParseExact(value, format,
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

        result = date;

        return parseResult;
    }
}