using System;
using System.Diagnostics;
using AutoMapper;
using PersonalFinanceManager.Areas.Administration.ViewModels;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.ViewModels.Books;
using PersonalFinanceManager.ViewModels.Categories;
using PersonalFinanceManager.ViewModels.MoneyStreams;

namespace PersonalFinanceManager
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BooksFormVM, Book>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                    .ReverseMap();
                cfg.CreateMap<CategoriesFormVM, Category>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();
                cfg.CreateMap<MoneyStreamsFormVM, MoneyStream>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dest => dest.IsIncome, opt => opt.MapFrom(src => src.IsIncome))
                    .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
                cfg.CreateMap<ApplicationUser, LockUserVM>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(src => src.LockoutEnabled));
            }
            );
        }
    }
}