using AutoMapper;
using ArtProducts.Data.Entities;
using ArtProducts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtProducts.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Orders, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id));

            CreateMap<OrderItems, OrderItemViewModel>()
                .ReverseMap();
        } 
    }
}
