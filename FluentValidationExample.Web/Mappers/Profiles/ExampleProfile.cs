using AutoMapper;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Web.Models;

namespace FluentValidationExample.Web.Mappers.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.First, opt => opt.MapFrom(model => model.FirstName))
                .ForMember(dto => dto.Last, opt => opt.MapFrom(model => model.LastName))
                .ForMember(dto => dto.Address, opt => opt.Unflatten())
                ;
        }
    }
}