using AutoMapper;
using Business_Layer__BL_.ViewModels;
using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Configuration
{
    public static class MapperConfig
    {
        // created ...mark
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                    cfg.CreateMap<AppIdentityUser, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<AppIdentityUser, RegisterViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
