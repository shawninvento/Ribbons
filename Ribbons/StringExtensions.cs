using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ribbons
{
    public static class StringExtensions
    {
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        private static readonly JsonSerializerOptions IndentedOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string ToJson(this object obj, bool indent = false)
        {
            return JsonSerializer.Serialize(obj, indent ? IndentedOptions : DefaultOptions);
        }
    }
}