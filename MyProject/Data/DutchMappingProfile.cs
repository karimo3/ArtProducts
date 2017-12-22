using AutoMapper;
using MyProject.Data.Entities;
using MyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id));
        } 
    }
}
