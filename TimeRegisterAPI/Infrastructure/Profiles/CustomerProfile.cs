using AutoMapper;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO.CustDTO;

namespace TimeRegisterAPI.Infrastructure.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerListViewDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<Customer, CustomerListViewDTO>().ReverseMap();
    }
}