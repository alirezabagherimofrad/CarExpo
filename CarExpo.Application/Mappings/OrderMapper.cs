using AutoMapper;
using CarExpo.Application.Commands.Command.OrserCommand;
using CarExpo.Domain.Models.Orders;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Mappings
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Car, Order>().ReverseMap();

            CreateMap<Car, OrderCommand>().ReverseMap();

            CreateMap<Order, OrderCommand>().ReverseMap();

            CreateMap<Order, OrderCommand>().ReverseMap();

            CreateMap<OrderCommand, OrderItem>().ReverseMap();
        }
    }
}
