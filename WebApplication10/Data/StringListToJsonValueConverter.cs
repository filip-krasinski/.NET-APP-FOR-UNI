using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication10.Data
{
    public class StringListToJsonValueConverter : ValueConverter<IEnumerable<string>, string>
    {
        public StringListToJsonValueConverter() : base(le => ListToString(le), s => StringToList(s))
        {

        }

        private static string ListToString(IEnumerable<string> value)
        {
            return JsonSerializer.Serialize(value);
        }

        private static IEnumerable<string> StringToList(string value)
        {
            return JsonSerializer.Deserialize<IEnumerable<string>>(value);
        }
    }
}