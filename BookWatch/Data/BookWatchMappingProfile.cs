using AutoMapper;
using BookWatch.ViewModel;
using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Data
{
    public class BookWatchMappingProfile :Profile
    {
        public BookWatchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
        .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
        .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
              .ReverseMap();
        }
    }
}
