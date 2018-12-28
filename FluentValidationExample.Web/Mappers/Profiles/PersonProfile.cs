using AutoMapper;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Web.Models;

namespace FluentValidationExample.Web.Mappers.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.First, opt => opt.MapFrom(model => model.FirstName))
                .ForMember(dto => dto.Last, opt => opt.MapFrom(model => model.LastName))
                ;
        }
    }
}