using AutoMapper;
using ToDoApi.MappingConverters;
using ToDoApi.Models.DTOs;
using ToDoApi.Models.Entities;

namespace ToDoApi
{
    public  class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<ToDoDto, ToDo>();
            CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();

            CreateMap<ToDo, ToDoDto>();
            CreateMap<DateTime,string>().ConvertUsing<DateToStringConverter>();
        }
    }
}
