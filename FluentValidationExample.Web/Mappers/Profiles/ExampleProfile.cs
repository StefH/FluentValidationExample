using AutoMapper;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Web.Models;

namespace FluentValidationExample.Web.Mappers.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<string, AddressDto>()
                .ForMember(x => x.Street, opt => opt.MapFrom(model => model));

            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.First, opt => opt.MapFrom(model => model.FirstName))
                .ForMember(dto => dto.Last, opt => opt.MapFrom(model => model.LastName))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(model => model.Street));
        }
    }
}