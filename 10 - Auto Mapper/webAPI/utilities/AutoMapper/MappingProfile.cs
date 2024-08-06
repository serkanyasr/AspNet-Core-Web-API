using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace webAPI.utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoObject, Book>();
        }
    }
}
