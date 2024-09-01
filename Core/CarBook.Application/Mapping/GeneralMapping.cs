using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Features.Mediator.Results.CategoryResults;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Domain.Entities;

namespace CarBook.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
            CreateMap<About, GetByIdAboutQueryResult>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();

            CreateMap<Banner, GetBannerQueryResult>().ReverseMap();
            CreateMap<Banner, GetByIdBannerQueryResult>().ReverseMap();
            CreateMap<Banner, CreateeBannerCommand>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommand>().ReverseMap();

            CreateMap<Brand, GetBrandQueryResult>().ReverseMap();
            CreateMap<Brand, GetByIdBrandQueryResult>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();

            CreateMap<Car, GetCarQueryResult>().ReverseMap();
            CreateMap<Car, GetByIdCarQueryResult>().ReverseMap();
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, GetCarWithBrandQueryResult>().ForMember(src => src.Name, opt => opt.MapFrom(x => x.Brand.Name));

            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetByIdCategoryQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Contact, GetContactQueryResult>().ReverseMap();
            CreateMap<Contact, GetByIdContactQueryResult>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
        }
    }
}
