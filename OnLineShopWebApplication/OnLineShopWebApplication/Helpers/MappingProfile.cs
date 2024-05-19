using AutoMapper;
using Microsoft.Extensions.Hosting;
using OnLineShop.Db.Models;
using OnLineShopWebApplication.Areas.Admin.Models;
using OnLineShopWebApplication.Models;
using System;

namespace OnLineShopWebApplication.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserDetailsViewModel>().ReverseMap();

            CreateMap<UserDeliveryData, AddUserViewModel>().ReverseMap();
            CreateMap<UserDeliveryData, UserDetailsViewModel>().ReverseMap();
            CreateMap<UserDeliveryData, UserDeliveryDataViewModel>().ReverseMap();

            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();

            CreateMap<OrderStatus, OrderStatusViewModel>().ReverseMap();
            CreateMap<BookCategoryViewModel, BookCategory>().ReverseMap();

            CreateMap<Product, AddProductViewModel>();
            CreateMap<Product, ProductViewModel>()
                    .ForMember(p => p.Cost, opt => opt.MapFrom(c => Decimal.Round(c.Cost)))
                    .ForMember(p => p.Images, opt => opt.MapFrom(i => i.Images.Select(x => x.Url).ToArray()))
                    .ForMember(o => o.Category, opt => opt.MapFrom(x => x.Category));

            CreateMap<Product, EditProductViewModel>()
                    .ForMember(p => p.Cost, opt => opt.MapFrom(c => Decimal.Round(c.Cost)))
                    .ForMember(p => p.ImagesPaths, opt => opt.MapFrom(i => i.Images.Select(x => x.Url).ToArray()));
            CreateMap<EditProductViewModel, Product>()
                    .ForMember(p => p.Images, opt => opt.MapFrom(i => i.ImagesPaths.Select(x => new Image { Url = x }).ToList()));

            CreateMap<Order, OrderViewModel>()
                    .ForMember(o => o.Cost, opt => opt.MapFrom(x => x.Items.Sum(x => x.Product.Cost * x.Amount)))
                    .ForMember(o => o.Status, opt => opt.MapFrom(x => x.Status))
                    .ForMember(o => o.DateTime, opt => opt.MapFrom(x => x.CreateDateTime.ToShortDateString()))
                    .ReverseMap();

        }
    }
}
