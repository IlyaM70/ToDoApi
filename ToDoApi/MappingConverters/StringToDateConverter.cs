using AutoMapper;
using System.Globalization;

namespace ToDoApi.MappingConverters
{
    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            DateTime dateTime;

            if (DateTime.TryParseExact(source, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }

            return default(DateTime);
        }
    }
}
