using AutoMapper;
using Clientes.Model;
using Core.Entities;
using System.Globalization;

namespace Clientes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerRequestModel>()
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => ParseDate(src.Birthdate)))
                .ReverseMap();
        }

        private static string ParseDate(DateTime? date)
        {
            return date != null ? date.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) : string.Empty;
        }
    }
}
