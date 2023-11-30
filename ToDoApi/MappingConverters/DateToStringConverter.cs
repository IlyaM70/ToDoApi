using AutoMapper;

namespace ToDoApi.MappingConverters
{
    public class DateToStringConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("dd-MM-yyyy HH:mm");
        }
    }
}
