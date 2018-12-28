using AutoMapper;
using FluentValidationExample.Business.Models.Public;
using FluentValidationExample.Web.Models;

namespace FluentValidationExample.Web.Mappers.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            //CreateMap<FlatObject, Address>();

            //CreateMap<FlatObject, Person>()
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src));


            //CreateMap<string, AddressDto>()
            //    .ConvertUsing(src => new AddressDto { Street =  src } )
            //    ;

            CreateMap<Person, PersonDto>()
                .ForMember(dto => dto.First, opt => opt.MapFrom(model => model.FirstName))
                .ForMember(dto => dto.Last, opt => opt.MapFrom(model => model.LastName))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(model => new AddressDto { Street = model.Street }))
                ;
        }
    }
}