using System.Globalization;

namespace Ocs.ApplicationLayer.Utils;

public static class DateTimeOffsetUtils
{
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