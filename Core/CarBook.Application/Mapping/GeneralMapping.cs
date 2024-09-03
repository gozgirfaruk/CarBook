using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Commands.AddressCommands;
using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Features.Mediator.Results.AddressResults;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Features.Mediator.Results.CategoryResults;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Features.Mediator.Results.FeatureReuslts;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
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

            CreateMap<Blog, GetBlogQueryResult>().ReverseMap();
            CreateMap<Blog, GetByIdBlogQueryResult>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogWithAuthorQueryResult>().ForMember(src=>src.Name, opt=>opt.MapFrom(y=>y.Author.Name));

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

            CreateMap<Feature, GetFeatureQueryResult>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureQueryResult>().ReverseMap();
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();

            CreateMap<FooterAdress, GetAddressQueryResult>().ReverseMap();
            CreateMap<FooterAdress, GetByIdAddressQueryResult>().ReverseMap();
            CreateMap<FooterAdress, CreateAddressCommand>().ReverseMap();
            CreateMap<FooterAdress, UpdateAddressCommand>().ReverseMap();

            CreateMap<Location, GetLocationQueryResult>().ReverseMap();
            CreateMap<Location, GetByIdLocationQueryResult>().ReverseMap();
            CreateMap<Location, CreateLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateLocationCommand>().ReverseMap();

            CreateMap<Pricing, GetPricingQueryResult>().ReverseMap();
            CreateMap<Pricing, GetByIdPricingQueryResult>().ReverseMap();
            CreateMap<Pricing, CreatePricingCommand>().ReverseMap();
            CreateMap<Pricing, UpdatePricingCommand>().ReverseMap();

            CreateMap<Service, GetServiceQueryResult>().ReverseMap();
            CreateMap<Service, GetByIdServiceQueryResult>().ReverseMap();
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Service, UpdateServiceCommand>().ReverseMap();

            CreateMap<SocialMedia, GetSocialMediaQueryResult>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaQueryResult>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<Testimonial, GetTestimonialQueryResult>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialQueryResult>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();


        }
    }
}
