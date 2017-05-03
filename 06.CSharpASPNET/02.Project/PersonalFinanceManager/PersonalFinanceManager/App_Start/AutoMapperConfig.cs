using AutoMapper;
using PersonalFinanceManager.Areas.Administration.ViewModels;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, LockUserVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))      
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(src => src.LockoutEnabled))
            .ReverseMap()
            );
        }
    }
}