using AutoMapper;
using CarExpo.Application.Commands.Command.PaymentRequestCommand;
using CarExpo.Domain.Models.Payment;
using CarExpo.Domain.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Application.Mappings.PaymentMap
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            CreateMap<Car, PaymentRequestCommand>().ReverseMap();

            CreateMap<Payment, PaymentRequestCommand>().ReverseMap();
        }
    }
}
